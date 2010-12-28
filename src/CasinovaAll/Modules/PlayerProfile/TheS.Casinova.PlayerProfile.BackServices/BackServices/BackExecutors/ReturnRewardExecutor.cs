using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.BackServices.BackExecutors
{
    public class ReturnRewardExecutor
        : SynchronousCommandExecutorBase<ReturnRewardCommand>
    {
        private IReturnReward _iReturnReward;
        private IGetUserProfile _iGetUserProfile;

        public ReturnRewardExecutor(IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iReturnReward = dac;
            _iGetUserProfile = dqr;
        }

        protected override void ExecuteCommand(ReturnRewardCommand command)
        {
            //ดึงข้อมูลผู้เล่น
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { GetUserProfileInfo = new UserProfile { UserName = command.UserProfile.UserName } };
            getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //อัพเดทชิฟเพิ่ม
            command.UserProfile.NonRefundable += getUserProfileCmd.PlayerProfile.NonRefundable;
            command.UserProfile.Refundable += getUserProfileCmd.PlayerProfile.Refundable;
            _iReturnReward.ApplyAction(command.UserProfile, command);
        }
    }
}
