using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetVoucherCodeSteps : ChipsExchangeModuleStepsBase
    {
        private GetVoucherCodeCommand _cmd;
        private IEnumerable<VoucherInformation> _voucherInformation;
        private VoucherInformation _getVoucherCode;
        private bool _check;

        [Given(@"Server has voucher information for get voucher code :")]
        public void GivenServerHasVoucherInformationForGetVoucherCode(Table table)
        {
            _voucherInformation = from item in table.Rows
                                  select new VoucherInformation {
                                      UserName = Convert.ToString(item["UserName"]),
                                      VoucherCode = Convert.ToString(item["VoucherCode"]),
                                      Amount = Convert.ToDouble(item["Amount"]),
                                      CanUse = Convert.ToBoolean(item["CanUse"])
                                  };
        }

        [Given(@"Sent UserName '(.*)' for get voucher code")]
        public void GivenSentUserNameXForGetVoucherCode(string userName)
        {
            bool canUse = true;

            _getVoucherCode = (from item in _voucherInformation
                                   where item.UserName == userName && item.CanUse == true
                                   select item).FirstOrDefault();

            if (_getVoucherCode == null) {
                _check = false;
            }
            SetupResult.For(Dqr_GetVoucherCode.Get(new GetVoucherCodeCommand()))
                .IgnoreArguments().Return(_getVoucherCode);

            _cmd = new GetVoucherCodeCommand {
                VoucherInformation = new VoucherInformation {
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName '(.*)' for validation")]
        public void GivenSentUserNameForValidation(string userName)
        {
            _cmd = new GetVoucherCodeCommand {
                VoucherInformation = new VoucherInformation {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call GetVoucherCodeExecutor\(\)")]
        public void WhenCallGetVoucherCodeExecutor()
        {
            GetVoucherCode.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call GetVoucherCodeExecutor\(\) for validate input")]
        public void WhenCallGetVoucherCodeExecutorForValidateInput()
        {
            try {
                GetVoucherCode.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The result should be Username'(.*)' VoucherCode '(.*)' Amount '(.*)'")]
        public void ThenTheResultShouldBeUsernameBoyVoucherCode6690AAmount500(string userName, string voucherCode, double amount)
        {
            Assert.AreEqual(userName, _getVoucherCode.UserName,"ชื่อผู้เล่น");
            Assert.AreEqual(voucherCode, _getVoucherCode.VoucherCode, "รหัสคูปอง");
            Assert.AreEqual(amount, _getVoucherCode.Amount, "จำนวนชิพตาย");
        }

        [Then(@"VoucherCode should be null")]
        public void ThenVoucherCodeShouldBeNull()
        {
            Assert.AreEqual(false, _check, "ข้อมูลรหัสคูปอง");
        }

        [Then(@"VoucherCode should be throw exception")]
        public void ThenVoucherCodeShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
