using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface ITwowinsDataAccess :
        ICreateBetInfo,
        ICreateActionLogInfo,
        IUpdateRoundInfo,
        IUpdateUserProfile,
        ICreateRangeBetInfo,
        IChangeBetInfo,
        IUpdateRoundWinnerInfo
    { }

    /// <summary>
    /// บันทึกข้อมูลการลงพนัน
    /// </summary>
    public interface ICreateBetInfo
        : ICreateData<BetInformation, CreateBetInfoCommand>
    { }

    /// <summary>
    /// บันทึกประวัติการดำเนินการ
    /// </summary>
    public interface ICreateActionLogInfo
        : ICreateData<ActionLogInformation, CreateActionLogInfoCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมุลดโต๊ะเกม
    /// </summary>
    public interface IUpdateRoundInfo
        : IDataAction<RoundInformation, UpdateRoundInfoCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public interface IUpdateUserProfile
        : IDataAction<UserProfile, UpdateUserProfileCommand>
    { }

    /// <summary>
    /// บันทึกข้อมูลการลงพนันแบบหลายมือ
    /// </summary>
    public interface ICreateRangeBetInfo
        : ICreateData<RangeBetInformation, CreateRangeBetInfoCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลการลงพนัน
    /// </summary>
    public interface IChangeBetInfo
        : IDataAction<BetInformation, ChangeBetInfoCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้ชนะของโต๊ะเกม
    /// </summary>
    public interface IUpdateRoundWinnerInfo
        : IDataAction<RoundWinnerInformation, UpdateRoundWinnerInfoCommand>
    { }
}
