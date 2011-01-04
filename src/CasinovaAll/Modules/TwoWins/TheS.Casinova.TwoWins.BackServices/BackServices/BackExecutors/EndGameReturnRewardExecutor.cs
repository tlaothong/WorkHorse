using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class EndGameReturnRewardExecutor
        : SynchronousCommandExecutorBase<EndGameReturnRewardCommand>
    {
        private IGetRoundWinnerInfo _iGetRoundWinnerInfo;
        private IGetSettingInfo _iGetSettingInfo;
        private IGetRoundInfo _iGetRoundInfo;
        private IGetUserProfile _iGetUserProfile;
        private IGetBetInfo _iGetBetInfo;

        public EndGameReturnRewardExecutor(ITwowinsDataBackQuery dqr)
        {
            _iGetRoundWinnerInfo = dqr;
            _iGetSettingInfo = dqr;
            _iGetRoundInfo = dqr;
            _iGetUserProfile = dqr;
            _iGetBetInfo = dqr;
        }

        protected override void ExecuteCommand(EndGameReturnRewardCommand command)
        {
            GetRoundWinnerCommand getRoundWinnerCmd = new GetRoundWinnerCommand { RoundID = command.RoundID };
            getRoundWinnerCmd.RoundWinnerInfo = _iGetRoundWinnerInfo.Get(getRoundWinnerCmd);

            GetSettingInfoCommand getSettingInfoCmd = new GetSettingInfoCommand { SettingName = command.SettingName };
            getSettingInfoCmd.SettingInfo = _iGetSettingInfo.Get(getSettingInfoCmd);

            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            List<UserProfile> userProfiles = new List<UserProfile>();

            //Hight normal reward
            userProfiles.Add(CalculateReward(getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormal,
                command.RoundID, getSettingInfoCmd.SettingInfo.WinnerHightNormalReturnRate, getRoundInfoCmd.RoundInfo.Pot));

            //Low normal reward
            userProfiles.Add(CalculateReward(getRoundWinnerCmd.RoundWinnerInfo.WinnerLowNormal,
                command.RoundID, getSettingInfoCmd.SettingInfo.WinnerLowNormalReturnRate, getRoundInfoCmd.RoundInfo.Pot));

            //Hight critical reward
            userProfiles.Add(CalculateReward(getRoundWinnerCmd.RoundWinnerInfo.WinnerHightCritical,
                command.RoundID, getSettingInfoCmd.SettingInfo.WinnerHightCriticalReturnRate, getRoundInfoCmd.RoundInfo.Pot));

            //Low critical reward
            userProfiles.Add(CalculateReward(getRoundWinnerCmd.RoundWinnerInfo.WinnerLowCritical,
                command.RoundID, getSettingInfoCmd.SettingInfo.WinnerLowCriticalReturnRate, getRoundInfoCmd.RoundInfo.Pot));

            #region backup code
            //GetBetInfoCommand getWinnerHightNormalBetInfoCmd = new GetBetInfoCommand { HandID = getRoundWinnerCmd.RoundWinnerInfo.WinnerHightNormal, RoundID = command.RoundID };
            //getWinnerHightNormalBetInfoCmd.BetInfo = _iGetBetInfo.Get(getWinnerHightNormalBetInfoCmd);

            //GetUserProfileCommand getWinnerHightNormalCmd = new GetUserProfileCommand { UserName = getWinnerHightNormalBetInfoCmd.BetInfo.UserName };
            //getWinnerHightNormalCmd.UserProfile = _iGetUserProfile.Get(getWinnerHightNormalCmd);

            //var winnerHightNormalReward = (getSettingInfoCmd.SettingInfo.WinnerHightNormalReturnRate * getRoundInfoCmd.RoundInfo.Pot) / 100;

            //getWinnerHightNormalCmd.UserProfile.NonRefundable += getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips;

            //if (winnerHightNormalReward > getWinnerHightNormalBetInfoCmd.BetInfo.Amount) {
            //    //กำไรที่ได้เป็นชิฟเป็น
            //    getWinnerHightNormalCmd.UserProfile.Refundable += winnerHightNormalReward - getWinnerHightNormalBetInfoCmd.BetInfo.Amount;                                                     

            //    //เงินต้นทุนทั้งหมด
            //    getWinnerHightNormalCmd.UserProfile.NonRefundable += getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips;
            //    getWinnerHightNormalCmd.UserProfile.Refundable += getWinnerHightNormalBetInfoCmd.BetInfo.Chips + winnerHightNormalReward;
            //}
            //else if ((winnerHightNormalReward < getWinnerHightNormalBetInfoCmd.BetInfo.Amount) && (winnerHightNormalReward != getWinnerHightNormalBetInfoCmd.BetInfo.Amount)) {
            //    if (getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips >= (getWinnerHightNormalBetInfoCmd.BetInfo.Amount) - winnerHightNormalReward) {
            //        //หักชิฟที่ขาดทุนจากชิฟตายก่อน
            //        getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips -= (getWinnerHightNormalBetInfoCmd.BetInfo.Amount) - winnerHightNormalReward;
            //    }
            //    else {
            //        getWinnerHightNormalBetInfoCmd.BetInfo.Chips -= ((getWinnerHightNormalBetInfoCmd.BetInfo.Amount) - winnerHightNormalReward) - getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips;
            //        getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips = 0;
            //    }

            //    getWinnerHightNormalCmd.UserProfile.NonRefundable += getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips;
            //    getWinnerHightNormalCmd.UserProfile.Refundable += getWinnerHightNormalBetInfoCmd.BetInfo.Chips;
            //}
            //else if (winnerHightNormalReward == getWinnerHightNormalBetInfoCmd.BetInfo.Amount) {
            //    getWinnerHightNormalCmd.UserProfile.NonRefundable += getWinnerHightNormalBetInfoCmd.BetInfo.BonusChips;
            //    getWinnerHightNormalCmd.UserProfile.Refundable += getWinnerHightNormalBetInfoCmd.BetInfo.Chips;
            //}
            #endregion backup code

            //TODO : ส่งข้อมูลเงิน(getUserProfileCmd.UserProfile)รางวัลให้ Reward ทำงานต่อ                
        }

        private UserProfile CalculateReward(int handID, int roundID, double returnRate, double pot) 
        {
            GetBetInfoCommand getBetInfoCmd = new GetBetInfoCommand { HandID = handID, RoundID = roundID };
            getBetInfoCmd.BetInfo = _iGetBetInfo.Get(getBetInfoCmd);

            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = getBetInfoCmd.BetInfo.UserName };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            var winnerReward = (returnRate * pot) / 100;

            getUserProfileCmd.UserProfile.NonRefundable += getBetInfoCmd.BetInfo.BonusChips;

            if (winnerReward > getBetInfoCmd.BetInfo.Amount) {
                //กำไรที่ได้เป็นชิฟเป็น
                getUserProfileCmd.UserProfile.Refundable += winnerReward - getBetInfoCmd.BetInfo.Amount;

                //เงินต้นทุนทั้งหมด
                getUserProfileCmd.UserProfile.NonRefundable += getBetInfoCmd.BetInfo.BonusChips;
                getUserProfileCmd.UserProfile.Refundable += getBetInfoCmd.BetInfo.Chips + winnerReward;
            }
            else if ((winnerReward < getBetInfoCmd.BetInfo.Amount) && (winnerReward != getBetInfoCmd.BetInfo.Amount)) {
                if (getBetInfoCmd.BetInfo.BonusChips >= (getBetInfoCmd.BetInfo.Amount) - winnerReward) {
                    //หักชิฟที่ขาดทุนจากชิฟตายก่อน
                    getBetInfoCmd.BetInfo.BonusChips -= (getBetInfoCmd.BetInfo.Amount) - winnerReward;
                }
                else {
                    getBetInfoCmd.BetInfo.Chips -= ((getBetInfoCmd.BetInfo.Amount) - winnerReward) - getBetInfoCmd.BetInfo.BonusChips;
                    getBetInfoCmd.BetInfo.BonusChips = 0;
                }

                getUserProfileCmd.UserProfile.NonRefundable += getBetInfoCmd.BetInfo.BonusChips;
                getUserProfileCmd.UserProfile.Refundable += getBetInfoCmd.BetInfo.Chips;
            }
            else if (winnerReward == getBetInfoCmd.BetInfo.Amount) {
                getUserProfileCmd.UserProfile.NonRefundable += getBetInfoCmd.BetInfo.BonusChips;
                getUserProfileCmd.UserProfile.Refundable += getBetInfoCmd.BetInfo.Chips;
            }

            return getUserProfileCmd.UserProfile;
        }
    }
}
