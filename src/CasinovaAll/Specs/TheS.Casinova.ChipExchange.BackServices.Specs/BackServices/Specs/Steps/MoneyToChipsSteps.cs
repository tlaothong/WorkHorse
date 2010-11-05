using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices.Commands;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class MoneyToChipsSteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<ExchangeSettingInformation> _exchangeSettingInfos;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private PlayerAccountInformation _playerAccountInfo;
        private ExchangeSettingInformation _exchangeSettingInfo;

        [Given(@"\(MoneyToChips\)server has exchange setting information as:")]
        public void GivenMoneyToChipsServerHasExchangeSettingInformationAs(Table table)
        {
            _exchangeSettingInfos = (from item in table.Rows
                                     select new ExchangeSettingInformation {
                                         Name = item["Name"],
                                         MinChipToMoneyExchange = Convert.ToDouble(item["MinChipToMoneyExchange"]),
                                         MinMoneyToChipExchange = Convert.ToDouble(item["MinMoneyToChipExchange"]),
                                         MoneyToChipRate = Convert.ToDouble(item["MoneyToChipRate"]),
                                         MoneyToBonusChipRate = Convert.ToDouble(item["MoneyToBonusChipRate"]),
                                         ChipToBonusChipRate = Convert.ToDouble(item["ChipToBonusChipRate"]),
                                         VoucherToBonusChipRate = Convert.ToDouble(item["VoucherToBonusChipRate"]),
                                     });
        }

        [Given(@"\(MoneyToChips\)server has player account information as:")]
        public void GivenMoneyToChipsServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfos = (from item in table.Rows
                                   select new PlayerAccountInformation {
                                       UserName = item["UserName"],
                                       FirstName = item["FirstName"],
                                       LastName = item["LastName"],
                                       AccountType = item["AccountType"],
                                       CardType = item["CardType"],
                                       AccountNo = Convert.ToDouble(item["AccountNo"]),
                                       CVV = Convert.ToInt32(item["CVV"]),
                                       ExpireDate = Convert.ToDateTime(item["ExpireDate"]),
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });
        }

        [Given(@"sent ExchangeSettingName: '(.*)' the exchange setting should recieved")]
        public void GivenSentExchangeSettingNameXTheExchangeSettingShouldRecieved(string exchangeSettingName)
        {
            _exchangeSettingInfo = (from item in _exchangeSettingInfos
                                    where item.Name == exchangeSettingName
                                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetExchangeSetting.Get(new GetExchangeSettingCommand()))
                .IgnoreArguments().Return(_exchangeSettingInfo);
        }

        [Given(@"exchange amount: '(.*)' should be more than minimum exchange rate")]
        public void GivenExchangeAmountXShouldBeMoreThanMinimumExchangeRate(double amount)
        {
            Assert.IsTrue(amount >= _exchangeSettingInfo.MinMoneyToChipExchange);
        }

        [Given(@"exchange amount: '(.*)' should be less than minimum exchange rate")]
        public void GivenExchangeAmountXShouldBeLessThanMinimumExchangeRate(double amount)
        {
            Assert.IsTrue(amount < _exchangeSettingInfo.MinMoneyToChipExchange);
        }

        [Given(@"sent UserName: '(.*)', AccountType: '(.*)' the player account information should recieved")]
        public void GivenSentUserNameXAccountTypeXThePlayerAccountInformationShouldRecieved(string userName, string accountType)
        {
            _playerAccountInfo = (from item in _playerAccountInfos
                                  where item.UserName == userName && item.AccountType == accountType
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments().Return(_playerAccountInfo);
        }

        [Given(@"the PayExchangeEngine should be call and complete transaction sent UserName: '(.*)', Amount: '(.*)', CardType: '(.*)', FistName: '(.*)', LastName: '(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)'")]
        public void GivenThePayExchangeEngineShouldBeCallAndCompleteTransactionSentUserNameXAmountXCardTypeXFistNameXLastNameXAccountNoXCVVXExpireDateX(string userName, double amount, string cardType, string firstName, string lastName, double accountNo, int cvv, DateTime expireDate)
        {
            Func<PayExchangeCommand, bool> checkData = (cmd) => {
                Assert.AreEqual(cmd.ExchangeInfo.UserName, userName, "UserName");
                Assert.AreEqual(cmd.ExchangeInfo.Amount, amount, "Amount");
                Assert.AreEqual(cmd.ExchangeInfo.CardType, cardType, "cardType");
                Assert.AreEqual(cmd.ExchangeInfo.FirstName, firstName, "FirstName");
                Assert.AreEqual(cmd.ExchangeInfo.LastName, lastName, "LastName");
                Assert.AreEqual(cmd.ExchangeInfo.AccountNo, accountNo, "AccountNo");
                Assert.AreEqual(cmd.ExchangeInfo.CVV, cvv, "CVV");
                Assert.AreEqual(cmd.ExchangeInfo.ExpireDate, expireDate, "ExpireDate");

                return true;
            };

            Svc_PayExchangeEngine.PayExchange(new PayExchangeCommand());
            LastCall.IgnoreArguments().Do(checkData);  
        }

        [Given(@"the user chips should be adding\(UserName: '(.*)', Amount:'(.*)'\)")]
        public void GivenTheUserChipsShouldBeAddingUserNameXAmountX(string userName, double amount)
        {
            Action<ExchangeInformation, MoneyToChipsCommand> checkData = (exchangeInfo, cmd) => {
                Assert.AreEqual(userName, exchangeInfo.UserName, "UserName");
                Assert.AreEqual(amount, exchangeInfo.Amount, "Amount");
            };

            Dac_IncreasePlayerChipsByMoney.ApplyAction(new ExchangeInformation(), new MoneyToChipsCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call MoneyToChipsExecutor\(UserName: '(.*)', Amount: '(.*)', AccountType: '(.*)'\)")]
        public void WhenCallMoneyToChipsExecutorUserNameXAmountXAccountTypeX(string userName, double amount, string accountType)
        {
            MoneyToChipsCommand cmd = new MoneyToChipsCommand {
                UserName = userName,
                Amount = amount,
                AccountType = accountType,
            };
            MoneyToChipsExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the result should be update")]
        public void ThenTheResultShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
