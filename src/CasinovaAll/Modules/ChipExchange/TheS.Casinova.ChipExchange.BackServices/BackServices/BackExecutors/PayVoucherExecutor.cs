using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class PayVoucherExecutor
        : SynchronousCommandExecutorBase<PayVoucherCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IUpdateUserProfile _iUpdateUserProfile;
        private ICreateVoucherInformation _iCreateVoucherInfo;
        private IGenerateVoucherCode _iGenVoucherCode;
        private double _playerBalance;
        private double _amount;

        public PayVoucherExecutor(IGenerateVoucherCode svc, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
            _iCreateVoucherInfo = dac;

            _iGenVoucherCode = svc;
        }

        protected override void ExecuteCommand(PayVoucherCommand command)
        {
            //Get user profile information
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.UserName,
            };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            _playerBalance = getUserProfileCmd.UserProfile.Refundable + getUserProfileCmd.UserProfile.NonRefundable;
            _amount = command.Amount;

            //UserProfile userProfile = new UserProfile { UserName = command.UserName };

            //Calculate chips for update balance
            if (_playerBalance >= _amount) {
                if ((_amount - getUserProfileCmd.UserProfile.NonRefundable) > 0) { //If bonus chip less than voucher amount
                    _amount -= getUserProfileCmd.UserProfile.NonRefundable;
                    getUserProfileCmd.UserProfile.Refundable -= _amount;
                    getUserProfileCmd.UserProfile.NonRefundable = 0;
                }
                else {
                    getUserProfileCmd.UserProfile.NonRefundable -= command.Amount;
                }
                
                //Update user profile(balance)
                _iUpdateUserProfile.ApplyAction(getUserProfileCmd.UserProfile, command);
               
                //Create new voucher information
                VoucherInformation voucherInfo = new VoucherInformation { 
                    //Call GenerateVoucherCode service for generate voucher code
                    VoucherCode = _iGenVoucherCode.GenerateVoucherCode(),
                    Amount = command.Amount,
                    UserName = command.UserName,
                    CanUse = true,
                };
                _iCreateVoucherInfo.Create(voucherInfo, command);
            }
            else {
                Console.WriteLine("################# ชิฟไม่พอแลกคูปอง ##################");
            }
        }
    }
}
