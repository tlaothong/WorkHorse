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
using PerfEx.Infrastructure.Validation;

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
                                       AccountNo = item["AccountNo"],
                                       CVV = item["CVV"],
                                       ExpireDate = Convert.ToDateTime(item["ExpireDate"]),
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });
        }

        [Given(@"\(MoneyToChips\)sent ExchangeSettingName: '(.*)' the exchange setting should recieved")]
        public void GivenMoneyToChipsSentExchangeSettingNameXTheExchangeSettingShouldRecieved(string exchangeSettingName)
        {
            _exchangeSettingInfo = (from item in _exchangeSettingInfos
                                    where item.Name == exchangeSettingName
                                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetExchangeSetting.Get(new GetExchangeSettingCommand()))
                .IgnoreArguments().Return(_exchangeSettingInfo);
        }

        [Given(@"\(MoneyToChips\)sent UserName: '(.*)', AccountType: '(.*)' the player account information should recieved")]
        public void GivenMoneyToChipsSentUserNameXAccountTypeXThePlayerAccountInformationShouldRecieved(string userName, string accountType)
        {
            _playerAccountInfo = (from item in _playerAccountInfos
                                  where item.UserName == userName && item.AccountType == accountType
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments().Return(_playerAccountInfo);
        }

        [Given(@"\(MoneyToChips\)the PayExchangeEngine should be call and complete transaction sent UserName: '(.*)', Amount: '(.*)', CardType: '(.*)', FistName: '(.*)', LastName: '(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)'")]
        public void GivenMoneyToChipsThePayExchangeEngineShouldBeCallAndCompleteTransactionSentUserNameXAmountXCardTypeXFistNameXLastNameXAccountNoXCVVXExpireDateX(string userName, double amount, string cardType, string firstName, string lastName, string accountNo, string cvv, DateTime expireDate)
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

        [Given(@"\(MoneyToChips\)the user chips should be adding\(UserName: '(.*)', Amount:'(.*)'\)")]
        public void GivenMoneyToChipsTheUserChipsShouldBeAddingUserNameXAmountX(string userName, double amount)
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
                ExchangeInformation = new ExchangeInformation {
                    UserName = userName,
                    Amount = amount,
                    AccountType = accountType,
                }
            };
            MoneyToChipsExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call MoneyToChipsExecutor\(UserName: '(.*)', Amount: '(.*)', AccountType: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallMoneyToChipsExecutorUserNameXAmountXAccountTypeX(string userName, double amount, string accountType)
        {
            try {
                MoneyToChipsCommand cmd = new MoneyToChipsCommand {
                    ExchangeInformation = new ExchangeInformation {
                        UserName = userName,
                        Amount = amount,
                        AccountType = accountType,
                    }
                };
                MoneyToChipsExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"\(MoneyToChips\)the result should be update")]
        public void ThenMoneyToChipsTheResultShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"\(MoneyToChips\)the result should be throw exception")]
        public void ThenMoneyToChipsTheResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
