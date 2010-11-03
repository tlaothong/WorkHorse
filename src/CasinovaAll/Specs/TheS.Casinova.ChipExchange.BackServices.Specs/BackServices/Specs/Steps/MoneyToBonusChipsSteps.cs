using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Commands;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class MoneyToBonusChipsSteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<ExchangeSettingInformation> _exchangeSettingInfos;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private IEnumerable<MultiLevelNetworkInformation> _multiLevelNetworkInfos;

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

        [Given(@"sent UserName: '(.*)' the MLN information should recieved")]
        public void GivenSentUserNameXTheMLNInformationShouldRecieved(string userName)
        {
            var qry = (from item in _multiLevelNetworkInfos
                       where item.Username == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetMLNInfo.Get(new GetMLNInfoCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"\(MoneyToBonusChips\)exchange amount: '2000' should be more than minimum exchange rate")]
        public void GivenMoneyToBonusChipsExchangeAmount2000ShouldBeMoreThanMinimumExchangeRate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"\(MoneyToBonusChips\)sent ExchangeSettingName: 'exchange1' the exchange setting should recieved")]
        public void GivenMoneyToBonusChipsSentExchangeSettingNameExchange1TheExchangeSettingShouldRecieved()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the user bonus chips should be adding\(UserName: 'OhAe', Amount:'8000'\)")]
        public void GivenTheUserBonusChipsShouldBeAddingUserNameOhAeAmount8000()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call MoneyToBonusChipsExecutor\(UserName: 'OhAe', Amount: '4000', AccountType: 'Secondary'\)")]
        public void WhenCallMoneyToBonusChipsExecutorUserNameOhAeAmount4000AccountTypeSecondary()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
