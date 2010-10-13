using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.BackServices
{
    public interface IGameTableBackService :
        ICreateGameTableConfigurations,
        ICheckActiveRoundToCreate 

    {}

    /// <summary>
    /// บันทึกการตั้งค่าเกม
    /// </summary>
    public interface ICreateGameTableConfigurations
    {
        void Create(CreateGameRoundConfigurationsCommand cmd);
    }

    /// <summary>
    /// ตรวจสอบจำนวน round ที่ active เพื่อสร้าง ActiveRound เพิ่ม
    /// </summary>
    public interface ICheckActiveRoundToCreate 
    {
        void Check(CheckActiveRoundToCreateCommand cmd);
    }

}
