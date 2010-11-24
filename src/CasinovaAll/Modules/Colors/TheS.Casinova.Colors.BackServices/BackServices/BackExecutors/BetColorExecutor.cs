﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class BetColorExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatePlayerActionInfo;

        private IGetPlayerInfo _iGetPlayerInfo;

        public BetColorExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iCreatePlayerActionInfo = dac;

            _iGetPlayerInfo = dqr;
        }

        protected override void ExecuteCommand(BetCommand command)
        {
            #region Update balance

            //ดึงข้อมูลผู้เล่นเพื่อหักเงิน
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.BetPlayerActionInfo.UserName,
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //บันทึกข้อมูลผู้เล่นที่ถูกหักเงิน
            PlayerInformation playerInfo = new PlayerInformation();
            getPlayerInfoCmd.PlayerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance - command.BetPlayerActionInfo.Amount;
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                UserName = playerInfo.UserName = command.BetPlayerActionInfo.UserName,

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                Balance = playerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance,               
            };
            _iUpdatePlayerInfoBalance.ApplyAction(playerInfo, updateBalanceCmd);

            #endregion Update balance

            #region Create player action information

            //บันทึกข้อมูลการดำเนินงานของผู้เล่น
            PlayerActionInformation playerActionInfo = new PlayerActionInformation();
            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName = playerActionInfo.UserName = command.BetPlayerActionInfo.UserName,
                RoundID = playerActionInfo.RoundID = command.BetPlayerActionInfo.RoundID,
                ActionType = playerActionInfo.ActionType = command.BetPlayerActionInfo.ActionType,
                Amount = playerActionInfo.Amount = command.BetPlayerActionInfo.Amount,
            };

            _iCreatePlayerActionInfo.Create(playerActionInfo, createPlayerActionInfoCmd);

            #endregion Create player action information
        }
    }
}
