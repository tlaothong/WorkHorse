using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class CalculateGameRoundWinnerExecutor
        : SynchronousCommandExecutorBase<CalculateGameRoundWinnerCommand>
    {
        private IListBetInfoByRoundID _iListBetInfoByRoundID;
        private IGetRoundWinnerInfo _iGetRoundWinnerInfo;
        private IUpdateRoundWinnerInfo _iUpdateRoundWinnerInfo;
        private IDependencyContainer _container;

        public CalculateGameRoundWinnerExecutor(IDependencyContainer container, ITwowinsDataAccess dac, ITwowinsDataBackQuery dqr)
        {
            _iListBetInfoByRoundID = dqr;
            _iGetRoundWinnerInfo = dqr;
            _iUpdateRoundWinnerInfo = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CalculateGameRoundWinnerCommand command)
        {
            List<BetAmountInformation> betAmountInfo = new List<BetAmountInformation>();

            ListBetInfoByRoundIDCommand listBetInfoByRoundIDCmd = new ListBetInfoByRoundIDCommand { RoundID = command.RoundID };
            listBetInfoByRoundIDCmd.BetInfoList = _iListBetInfoByRoundID.List(listBetInfoByRoundIDCmd);

            //TODO : Validation ว่าโต๊ะเกมมีการเริ่มเล่นหรือจบเกมไปแล้ว
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            RoundInformation roundInfo = new RoundInformation { RoundID = command.RoundID };
            ValidationHelper.Validate(_container, roundInfo, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //หามือที่ซ้ำกันของ Amount ที่มีการลง
            foreach (var item in listBetInfoByRoundIDCmd.BetInfoList) {
                var betInfo = listBetInfoByRoundIDCmd.BetInfoList.Select(x => x)
                    .Where(x => (x.Amount == item.Amount) 
                        && (x.HandStatus == item.HandStatus));
                BetAmountInformation betAmount = new BetAmountInformation {
                    Amount = item.Amount,
                    Count = betInfo.Count(),
                    HandStatus = item.HandStatus,
                };
                betAmountInfo.Add(betAmount);
            }

            //ดึงข้อมูลผู้ชนะของโต๊ะเกม
            GetRoundWinnerCommand getRoundWinnerCmd = new GetRoundWinnerCommand { RoundID = command.RoundID };
            getRoundWinnerCmd.RoundWinnerInfo = _iGetRoundWinnerInfo.Get(getRoundWinnerCmd);

            //แยกตรวจสอบผู้ชนะประเภท Normal
            var normalAmountInfo = (from item in betAmountInfo.Select(x => x).Where(x => x.HandStatus == "Normal")
                                    orderby item.Count, item.Amount ascending
                                    select item);

            foreach (var item in normalAmountInfo) {
                #region set initialize winner
                //กำหนดผู้ชนะให้เป็นค่าไหนก่อนก็ได้ ในกรณีที่เกมพึ่งเริ่ม
                if (getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount == -1) {
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount = item.Amount;
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalCount = 1;
                }
                if (getRoundWinnerCmd.RoundWinnerInfo.WinnerLowNormalAmount == -1) {
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerLowNormalAmount = item.Amount;
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerLowNormalCount = 1;
                }
                if (getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount == -1) {
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount = item.Amount;
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalCount = 1;
                }
                if (getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount == -1) {
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount = item.Amount;
                    getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalCount = 1;
                }
                #endregion set initialize winner

                //เช็ค WinnerHightNormal
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalCount) {
                    if (item.Amount > getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalCount = item.Count;
                    }
                }
                //เช็ค WinnerLowNormal
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerLowNormalCount) {
                    if (item.Amount < getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormalCount = item.Count;
                    }
                }
                //เช็ค WinnerHightCritical
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalCount) {
                    if (item.Amount > getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalCount = item.Count;
                    }
                }
                //เช็ค WinnerLowCritical
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalCount) {
                    if (item.Amount < getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalCount = item.Count;
                    }
                }
            }

            //แยกตรวจสอบผู้ชนะประเภท Critical
            var criticalAmountInfo = (from item in betAmountInfo.Select(x => x).Where(x => x.HandStatus == "Critical")
                                    orderby item.Count ascending
                                    select item);

            foreach (var item in criticalAmountInfo) {
                //เช็ค WinnerHightCritical
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalCount) {
                    if (item.Amount > getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCriticalCount = item.Count;
                    }
                }
                //เช็ค WinnerLowCritical
                if (item.Count <= getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalCount) {
                    if (item.Amount < getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount) {
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalAmount = item.Amount;
                        getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCriticalCount = item.Count;
                    }
                }
            }

            //อัพเดทผู้ชนะของโต๊ะเกม
            UpdateRoundWinnerInfoCommand updateRoundWinnerInfoCmd = new UpdateRoundWinnerInfoCommand { 
                RoundWinnerInfo = getRoundWinnerCmd.RoundWinnerInfo
            };
            _iUpdateRoundWinnerInfo.ApplyAction(updateRoundWinnerInfoCmd.RoundWinnerInfo, updateRoundWinnerInfoCmd);
        }
    }
}
