using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ChipExchange.Commands;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class VoucherToBonusChipsSteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<VoucherInformation> _voucherInfos;
        private IEnumerable<ExchangeSettingInformation> _exchangeSettingInfos;
        private ExchangeSettingInformation _exchangeSettingInfo;
        private VoucherInformation _voucherInfo;

        [Given(@"\(VoucherToBonusChips\)server has voucher information as:")]
        public void GivenVoucherToBonusChipsServerHasVoucherInformationAs(Table table)
        {
            _voucherInfos = (from item in table.Rows
                             select new VoucherInformation {
                                 VoucherCode = item["Code"],
                                 UserName = item["UserName"],
                                 Amount = Convert.ToDouble(item["Amount"]),
                                 CanUse = Convert.ToBoolean(item["CanUser"]),
                             });
        }

        [Given(@"\(VoucherToBonusChips\)server has exchange setting information as:")]
        public void GivenVoucherToBonusChipsServerHasExchangeSettingInformationAs(Table table)
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

        [Given(@"\(VoucherToBonusChips\)sent Code: '(.*)' the voucher information should recieved")]
        public void GivenVoucherToBonusChipsSentCodeXTheVoucherInformationShouldRecieved(string code)
        {
            _voucherInfo = (from item in _voucherInfos
                            where item.VoucherCode == code
                            select item).FirstOrDefault();

            SetupResult.For(Dqr_GetVoucherInfo.Get(new ChipExchange.Commands.GetVoucherInfoCommand()))
                .IgnoreArguments().Return(_voucherInfo);
        }

        [Given(@"\(VoucherToBonusChips\)request voucher avaliable for exchange")]
        public void GivenVoucherToBonusChipsRequestVoucherAvaliableForExchange()
        {
            Assert.IsTrue(_voucherInfo.CanUse, "CanUse");
        }
        
        [Given(@"\(VoucherToBonusChips\)request voucher not avaliable for exchange")]
        public void GivenVoucherToBonusChipsRequestVoucherNotAvaliableForExchange()
        {
            Assert.IsTrue(!(_voucherInfo.CanUse), "CanUse");
        }

        [Given(@"\(VoucherToBonusChips\)sent ExchangeSettingName: '(.*)' the exchange setting should recieved")]
        public void GivenVoucherToBonusChipsSentExchangeSettingNameXTheExchangeSettingShouldRecieved(string exchangeSettingName)
        {
            _exchangeSettingInfo = (from item in _exchangeSettingInfos
                                    where item.Name == exchangeSettingName
                                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetExchangeSetting.Get(new GetExchangeSettingCommand()))
                .IgnoreArguments().Return(_exchangeSettingInfo);
        }

        [Given(@"\(VoucherToBonusChips\)voucher should be update\(Code: '(.*)'\)")]
        public void GivenVoucherToBonusChipsVoucherShouldBeUpdateCodeX(string code)
        {
            Action<VoucherInformation, UpdateUsedVoucherCommand> checkData = (voucherInfo, cmd) => {
                Assert.AreEqual(_voucherInfo.VoucherCode, voucherInfo.VoucherCode, "VoucherCode");
                Assert.AreEqual(false, voucherInfo.CanUse, "CanUser");
            };

            Dac_UpdateUsedVoucher.ApplyAction(new VoucherInformation(), new UpdateUsedVoucherCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(VoucherToBonusChips\)the user bonus chips should be adding\(UserName: '(.*)', Amount:'(.*)'\)")]
        public void GivenVoucherToBonusChipsTheUserBonusChipsShouldBeAddingUserNameXAmountX(string userName, double amount)
        {
            Action<ExchangeInformation, VoucherToBonusChipsCommand> checkData = (exchangeInfo, cmd) => {
                Assert.AreEqual(userName, exchangeInfo.UserName, "UserName");
                Assert.AreEqual(amount, exchangeInfo.Amount, "Amount");
            };

            Dac_IncreasePlayerBonusChipsByVoucher.ApplyAction(new ExchangeInformation(), new VoucherToBonusChipsCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call VoucherToBonusChipsExecutor\(Code: '(.*)', UserName: '(.*)'\)")]
        public void WhenCallVoucherToBonusChipsExecutorCodeXUserNameX(string code, string userName)
        {
            VoucherToBonusChipsCommand cmd = new VoucherToBonusChipsCommand {
                UserName = userName,
                VoucherCode = code,
            };

            VoucherToBonusChipsExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the player profile should be update")]
        public void ThenThePlayerProfileShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
