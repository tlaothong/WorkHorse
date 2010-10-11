using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.BackServices
{
    public interface IGameTableBackService :
        ICreateGameTableConfigurations

    {}

    /// <summary>
    /// บันทึกการตั้งค่าเกม
    /// </summary>
    public interface ICreateGameTableConfigurations
    {
        void Create(CreateGameTableConfigurationsCommand cmd);
    }
}
