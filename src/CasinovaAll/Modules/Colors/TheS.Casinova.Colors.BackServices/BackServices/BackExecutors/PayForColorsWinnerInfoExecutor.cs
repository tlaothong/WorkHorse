using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor 
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private double _payFee;

        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatPlayerActionInfo;
        private IUpdateOnGoingTrackingID _iUpdateOnGoingTrackingID;
        private IUpdateRoundWinner _iUpdateRoundWinner;

        private IGetPlayerInfo _iGetPlayerInfo;
        private IListPlayerActionInfoQuery _iListPlayerActionInfo;        
        private IGetRoundInfo _iGetRoundInfo;

        private string _winner;
        private PlayerActionInformation _playerActionInfo;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateOnGoingTrackingID = dac;
            _iCreatPlayerActionInfo = dac;
            _iUpdateRoundWinner = dac;

            _iGetPlayerInfo = dqr;
            _iGetRoundInfo = dqr;
            _iListPlayerActionInfo = dqr;

            _winner = null;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            //var balance = _iGetPlayerInfo.Get(command);

            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                PlayerInfo = new PlayerInformation { UserName = command.UserName }
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
            var betCount = _iListPlayerActionInfo.List(command);

            //กำหนดเงินที่จะหัก
            if (betCount.Count() >= 1) {
                _payFee = 1;
            }
            else {
                _payFee = 5;
            }

            //หักเงินผู้เล่น
            if (getPlayerInfoCmd.PlayerInfo.Balance >= _payFee) {
                getPlayerInfoCmd.PlayerInfo.Balance -= _payFee;

                UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                    PlayerInfo = getPlayerInfoCmd.PlayerInfo
                };

                _iUpdatePlayerInfoBalance.ApplyAction(updatePlayerInfoBalanceCmd.PlayerInfo, updatePlayerInfoBalanceCmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //บันทึกข้อมูล PlayerActionInformation
            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    RoundID = command.RoundID,
                    UserName = command.UserName,
                    ActionType = "GetWinner",
                    Amount = _payFee,
                }
            };
            _iCreatPlayerActionInfo.Create(createPlayerActionInfoCmd.PlayerActionInfo, createPlayerActionInfoCmd);

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            UpdateOnGoingTrackingIDCommand updateOnGoingTrackingIDCmd = new UpdateOnGoingTrackingIDCommand {
                GamePlayInfo = new GamePlayInformation {
                    RoundID = command.RoundID,
                    UserName = command.UserName,
                    OnGoingTrackingID = command.GamePlayInfo.OnGoingTrackingID,
                }
            };
            _iUpdateOnGoingTrackingID.ApplyAction(updateOnGoingTrackingIDCmd.GamePlayInfo, updateOnGoingTrackingIDCmd);

            #endregion Update balance

            #region Get round winner

            //ดึงข้อมูล Winner
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { 
                RoundID = command.RoundID
            };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (getRoundInfoCmd.RoundInfo.WhitePot <= getRoundInfoCmd.RoundInfo.BlackPot) {
                _winner = "White";
            }
            else {
                _winner = "Black";
            }

            #endregion Get round winner

            #region Update game play information

            UpdateRoundWinnerCommand updateRoundWinnerCmd = new UpdateRoundWinnerCommand {
                GamePlayInfo = new GamePlayInformation {
                    RoundID = command.RoundID,
                    UserName = command.UserName,
                    Winner = _winner,
                    TrackingID = command.GamePlayInfo.OnGoingTrackingID,
                    LastUpdate = DateTime.Now,
                }
            };
            
            //บันทึกข้อมูล Winner และ TrackingID ที่ผู้เล่นร้องขอ
            _iUpdateRoundWinner.ApplyAction(updateRoundWinnerCmd.GamePlayInfo, updateRoundWinnerCmd);

            #endregion Update game play information
        }
    }
}
