﻿using System;
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
        IUpdateUserProfile

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
        : IDataAction<RoundInformation, UpdateRoundCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public interface IUpdateUserProfile
        : IDataAction<UserProfile, UpdateUserProfileCommand>
    { }
}
