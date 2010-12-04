using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลโปรไฟล์ของผู้เล่น
    /// </summary>
    public class GetUserProfileExecutor
     : SynchronousCommandExecutorBase<GetUserProfileCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IDependencyContainer _container;

        public GetUserProfileExecutor(IPlayerProfileDataQuery dqr, IDependencyContainer container)
        {
            _iGetUserProfile = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(GetUserProfileCommand command)
        {
            bool active = true;

            //Validation
            var errors = ValidationHelper.Validate(_container, command.GetUserProfileInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
      
            command = new GetUserProfileCommand {
                GetUserProfileInfo = new UserProfile {
                    Active = active
                }
            };
            command.PlayerProfile = _iGetUserProfile.Get(command);
        }
    }
}
