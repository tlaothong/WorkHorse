using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.BackServices
{
    public interface IEmailSender
    {
        void SendingValidationEmail(UserProfile userProfile, RegisterUserCommand command);
    }
}
