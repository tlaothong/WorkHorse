using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class CalculateGameRoundWinnerExecutor
        : SynchronousCommandExecutorBase<CalculateGameRoundWinnerCommand>
    {
        private IListPlayerActionInfoQuery _iListPlayerActionInfoQuery;
        private IGetRoundInfo _iGetRoundInfo;
        private IGetPlayerInfo _iGetPlayerInfo;

        public CalculateGameRoundWinnerExecutor(IColorsGameDataBackQuery dqr)
        {
            _iListPlayerActionInfoQuery = dqr;
            _iGetRoundInfo = dqr;
            _iGetPlayerInfo = dqr;
        }

        protected override void ExecuteCommand(CalculateGameRoundWinnerCommand command)
        {
            IEnumerable<PlayerActionInformation> winnerList;
            double returnRate = 2;
            string winnerColor;

            //ดึงข้อมูลโต๊ะเกม
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            //ดึงข้อมูลการลงพนันของโต๊ะเกม
            ListPlayerActionInfoCommand listPlayerActionInfoCmd = new ListPlayerActionInfoCommand {
                RoundID = command.RoundID
            };

            listPlayerActionInfoCmd.PlayerActionInfoList = _iListPlayerActionInfoQuery.List(listPlayerActionInfoCmd);

            if (getRoundInfoCmd.RoundInfo.WhitePot <= getRoundInfoCmd.RoundInfo.BlackPot) {
                winnerColor = "White";
            }
            else { 
                winnerColor = "Black"; 
            }
            winnerList = (from item in listPlayerActionInfoCmd.PlayerActionInfoList
                          where item.ActionType == winnerColor
                          select item);

            //TODO : Validation ว่าโต๊ะเกมที่ส่งมาจบเกมแล้ว

            foreach (var winner in winnerList) {
                UserProfile userProfile = new UserProfile { UserName = winner.UserName };
                var qry = (from item in listPlayerActionInfoCmd.PlayerActionInfoList
                           where item.UserName == winner.UserName
                           select item);

                userProfile.NonRefundable = qry.Select(x => x.BonusChips).Sum();
                userProfile.Refundable = qry.Select(x => x.Chips).Sum();

                //ดึงข้อมูลของผู้เล่น
                GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand { UserName = userProfile.UserName };
                getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);

                var winnerAmount = winner.Amount * returnRate;
                var netAmount = userProfile.NonRefundable + userProfile.Refundable;

                if (winnerAmount > netAmount) {
                    //กำไรที่ได้เป็นชิฟเป็น
                    getPlayerInfoCmd.UserProfile.Refundable += winnerAmount - (netAmount);

                    //เงินต้นทุนทั้งหมด
                    getPlayerInfoCmd.UserProfile.NonRefundable += userProfile.NonRefundable;
                    getPlayerInfoCmd.UserProfile.Refundable += userProfile.Refundable;
                }
                else if ((winnerAmount < netAmount) && (winner.Amount != netAmount)) {
                    if (userProfile.NonRefundable != 0) {
                        //หักชิฟที่ขาดทุนจากชิฟตายก่อน
                        userProfile.NonRefundable -= (netAmount) - winnerAmount;
                    }
                    else {
                        userProfile.Refundable -= (netAmount) - winnerAmount;
                    }

                    getPlayerInfoCmd.UserProfile.NonRefundable += userProfile.NonRefundable;
                    getPlayerInfoCmd.UserProfile.Refundable += userProfile.Refundable;
                }

                //TODO : ส่งข้อมูลเงินรางวัลให้ Reward ทำงานต่อ                
            }
        }
    }
}
