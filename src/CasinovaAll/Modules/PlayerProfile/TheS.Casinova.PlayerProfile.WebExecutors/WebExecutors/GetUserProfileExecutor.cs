using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลโปรไฟล์ของผู้เล่น
    /// </summary>
    public class GetUserProfileExecutor
     : SynchronousCommandExecutorBase<GetUserProfileCommand>       
    {
        private IGetUserProfile _iGetUserProfile;

        public GetUserProfileExecutor(IPlayerProfileDataQuery dqr) 
       {
           _iGetUserProfile = dqr;
       }

        protected override void ExecuteCommand(GetUserProfileCommand command)
       {
           command.PlayerProfile = _iGetUserProfile.Get(command);
       }
    }
}
