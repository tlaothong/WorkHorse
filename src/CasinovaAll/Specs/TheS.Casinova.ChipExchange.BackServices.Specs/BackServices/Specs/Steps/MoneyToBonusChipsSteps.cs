using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ChipExchange.BackServices.Commands;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class MoneyToBonusChipsSteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<ExchangeSettingInformation> _exchangeSettingInfos;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private IEnumerable<MultiLevelNetworkInformation> _multiLevelNetworkInfos;
        private MultiLevelNetworkInformation _multiLevelNetworkInfo;
        private ExchangeSettingInformation _exchangeSettingInfo;
        private PlayerAccountInformation _playerAccountInfo;

        [Given(@"\(MoneyToBonusChips\)server has exchange setting information as:")]
        public void GivenMoneyToBonusChipsServerHasExchangeSettingInformationAs(Table table)
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

        [Given(@"\(MoneyToBonusChips\)server has MLN information as:")]
        public void GivenMoneyToBonusChipsServerHasMLNInformationAs(Table table)
        {
            _multiLevelNetworkInfos = (from item in table.Rows
                                       select new MultiLevelNetworkInformation {
                                           Username = item["UserName"],
                                           Bonus = Convert.ToInt32(item["Bonus"]),
                                       });
        }

        [Given(@"\(MoneyToBonusChips\)server has player account information as:")]
        public void GivenMoneyToBonusChipsServerHasPlayerAccountInformationAs(Table table)
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

        [Given(@"\(MoneyToBonusChips\)sent UserName: '(.*)' the MLN information should recieved")]
        public void GivenSentUserNameXTheMLNInformationShouldRecieved(string userName)
        {
            _multiLevelNetworkInfo = (from item in _multiLevelNetworkInfos
                                      where item.Username == userName
                                      select item).FirstOrDefault();

            SetupResult.For(Dqr_GetMLNInfo.Get(new GetMLNInfoCommand()))
                .IgnoreArguments().Return(_multiLevelNetworkInfo);
        }

        [Given(@"\(MoneyToBonusChips\)exchange amount: '(.*)' should be more than player bonus")]
        public void GivenMoneyToBonusChipsExchangeAmountXShouldBeMoreThanPlayerBonus(double amount)
        {
            Assert.IsTrue(_multiLevelNetworkInfo.Bonus >= amount, "Bonus");
        }

        [Given(@"\(MoneyToBonusChips\)sent ExchangeSettingName: '(.*)' the exchange setting should recieved")]
        public void GivenMoneyToBonusChipsSentExchangeSettingNameXTheExchangeSettingShouldRecieved(string exchangeSettingName)
        {
            _exchangeSettingInfo = (from item in _exchangeSettingInfos
                                    where item.Name == exchangeSettingName
                                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetExchangeSetting.Get(new GetExchangeSettingCommand()))
                .IgnoreArguments().Return(_exchangeSettingInfo);
        }

        [Given(@"\(MoneyToBonusChips\)exchange amount: '(.*)' should be more than minimum exchange rate")]
        public void GivenMoneyToBonusChipsExchangeAmountXShouldBeMoreThanMinimumExchangeRate(double amount)
        {
            Assert.IsTrue(amount >= _exchangeSettingInfo.ChipToBonusChipRate);
        }

        [Given(@"\(MoneyToBonusChips\)exchange amount: '(.*)' should be less than minimum exchange rate")]
        public void GivenMoneyToBonusChipsExchangeAmountXShouldBeLessThanMinimumExchangeRate(double amount)
        {
            Assert.IsTrue(amount < _exchangeSettingInfo.MinMoneyToChipExchange);
        }

        [Given(@"\(MoneyToBonusChips\)sent UserName: '(.*)', AccountType: '(.*)' the player account information should recieved")]
        public void GivenMoneyToBonusChipsSentUserNameXAccountTypeXThePlayerAccountInformationShouldRecieved(string userName, string accountType)
        {
            _playerAccountInfo = (from item in _playerAccountInfos
                                  where item.UserName == userName && item.AccountType == accountType
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments().Return(_playerAccountInfo);
        }

        [Given(@"\(MoneyToBonusChips\)the PayExchangeEngine should be call and complete transaction sent UserName: '(.*)', Amount: '(.*)', CardType: '(.*)', FistName: '(.*)', LastName: '(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)'")]
        public void GivenMoneyToBonusChipsThePayExchangeEngineShouldBeCallAndCompleteTransactionSentUserNameXAmountXCardTypeXFistNameXLastNameXAccountNoXCVVXExpireDateX(string userName, double amount, string cardType, string firstName, string lastName, double accountNo, int cvv, DateTime expireDate)
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

        [Given(@"\(MoneyToBonusChips\)the user bonus chips should be adding\(UserName: '(.*)', Amount:'(.*)'\)")]
        public void GivenTheUserBonusChipsShouldBeAddingUserNameXAmountX(string userName, double amount)
        {
            Action<ExchangeInformation, MoneyToBonusChipsCommand> checkData = (exchangeInfo, cmd) => {
                Assert.AreEqual(userName, exchangeInfo.UserName, "UserName");
                Assert.AreEqual(amount, exchangeInfo.Amount, "Amount");
            };

            Dac_IncreasePlayerBonusChipsByMoney.ApplyAction(new ExchangeInformation(), new MoneyToBonusChipsCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call MoneyToBonusChipsExecutor\(UserName: '(.*)', Amount: '(.*)', AccountType: '(.*)'\)")]
        public void WhenCallMoneyToBonusChipsExecutorUserNameXAmountXAccountTypeSecondary(string userName, double amount, string accountType)
        {
            MoneyToBonusChipsCommand cmd = new MoneyToBonusChipsCommand {
                UserName = userName,
                Amount = amount,
                AccountType = accountType,
            };
            MoneyToBonusChipsExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"\(MoneyToBonusChips\)the result should be update")]
        public void ThenMoneyToBonusChipsTheResultShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"abort operation")]
        public void ThenAbortOperation()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
