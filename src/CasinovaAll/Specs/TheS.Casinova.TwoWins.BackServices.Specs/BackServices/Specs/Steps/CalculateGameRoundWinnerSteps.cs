using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    [Binding]
    public class CalculateGameRoundWinnerSteps
        : TwowinsStepsBase
    {
        private IEnumerable<RoundWinnerInformation> _roundWinnerInfos;
        private IEnumerable<BetInformation> _betInfos;
        private IEnumerable<RoundInformation> _roundInfos;
        private RoundWinnerInformation _roundWinnerInfo;
        private IEnumerable<BetInformation> _betInfoList;
        private RoundInformation _roundInfo;

        [Given(@"\(Twowins_CalculateGameRoundWinner\)server has game round winner information as:")]
        public void GivenTwowins_CalculateGameRoundWinnerServerHasGameRoundWinnerInformationAs(Table table)
        {
            _roundWinnerInfos = (from item in table.Rows
                                 select new RoundWinnerInformation {
                                     RoundID = Convert.ToInt32(item["RoundID"]),
                                     WinnerHightNormalAmount = Convert.ToDouble(item["WinnerHiNorAmount"]),
                                     WinnerHightNormalCount = Convert.ToInt32(item["WinnerHiNorCount"]),
                                     WinnerLowNormalAmount = Convert.ToDouble(item["WinnerLoNorAmount"]),
                                     WinnerLowNormalCount = Convert.ToInt32(item["WinnerLoNorCount"]),
                                     WinnerHightCriticalAmount = Convert.ToDouble(item["WinnerHiCriAmount"]),
                                     WinnerHightCriticalCount = Convert.ToInt32(item["WinnerHiCriCount"]),
                                     WinnerLowCriticalAmount = Convert.ToDouble(item["WinnerLoCriAmount"]),
                                     WinnerLowCriticalCount = Convert.ToInt32(item["WinnerLoCriCount"]),
                                 });
        }
        
        [Given(@"\(Twowins_CalculateGameRoundWinner\)server has bet information as:")]
        public void GivenTwowins_CalculateGameRoundWinnerServerHasBetInformationAs(Table table)
        {
            _betInfos = (from item in table.Rows
                         select new BetInformation {
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             UserName = item["UserName"],
                             Amount = Convert.ToDouble(item["Amount"]),
                             HandID = Convert.ToInt32(item["HandID"]),
                             HandStatus = item["HandStatus"],
                             CanChange = Convert.ToBoolean(item["CanChange"]),
                         });
        }

        [Given(@"\(Twowins_CalculateGameRoundWinner\)server has round information as:")]
        public void GivenTwowins_ChangeBetServerHasRoundInformationAs(Table table)
        {
            _roundInfos = from item in table.Rows
                          select new RoundInformation {
                              RoundID = Convert.ToInt32(item["RoundID"]),
                              Pot = Convert.ToDouble(item["Pot"]),
                              FromDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["FromDateTime"])),
                              ThruDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["ThruDateTime"])),
                              CriticalDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["CriticalTime"])),
                          };
        }
        
        [Given(@"\(Twowins_CalculateGameRoundWinner\)sent RoundID: '(.*)' the bet information should recieved")]
        public void GivenTwowins_CalculateGameRoundWinnerSentRoundIDXTheBetInformationShouldRecieved(int roundID)
        {
            _betInfoList = (from item in _betInfos
                            where item.RoundID == roundID
                            select item);
            SetupResult.For(Dqr_ListBetInfoByRoundID.List(new ListBetInfoByRoundIDCommand()))
                .IgnoreArguments().Return(_betInfoList);
        }

        [Given(@"\(Twowins_CalculateGameRoundWinner\)sent RoundID: '(.*)' the round winner information should recieved")]
        public void GivenTwowins_CalculateGameRoundWinnerSentRoundIDXTheRoundWinnerInformationShouldRecieved(int roundID)
        {
            _roundWinnerInfo = (from item in _roundWinnerInfos
                                where item.RoundID == roundID
                                select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundWinnerInfo.Get(new GetRoundWinnerCommand()))
                .IgnoreArguments().Return(_roundWinnerInfo);
        }

        [Given(@"\(Twowins_CalculateGameRoundWinner\)sent roundID: '(.*)' the round information should recieved")]
        public void GivenTwowins_ChangeBetSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            _roundInfo = (from item in _roundInfos
                          where item.RoundID == roundID
                          select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundInfo.Get(new GetRoundInfoCommand()))
                .IgnoreArguments().Return(_roundInfo);
        }
        
        [Given(@"\(Twowins_CalculateGameRoundWinner\)the round winner information should be update \(RoundID ='(.*)', WinnerHiNorAmount ='(.*)', WinnerHiNorCount ='(.*)', WinnerLoNorAmount ='(.*)', WinnerLoNorCount ='(.*)', WinnerHiCriAmount ='(.*)', WinnerHiCriCount ='(.*)', WinnerLoCriAmount ='(.*)', WinnerLoCriCount ='(.*)'\)")]
        public void GivenTwowins_CalculateGameRoundWinnerTheRoundWinnerInformationShouldBeUpdateRoundIDXWinnerHiNorAmountXWinnerHiNorCountXWinnerLoNorAmountXWinnerLoNorCountXWinnerHiCriAmountXWinnerHiCriCountXWinnerLoCriAmountXWinnerLoCriCountX(int roundID, double winnerHiNorAmount, int winnerHiNorCount, double winnerLoNorAmount, int winnerLoNorCount, double winnerHiCriAmount, int winnerHiCriCount, double winnerLoCriAmount, int winnerLoCriCount)
        {
            Action<RoundWinnerInformation, UpdateRoundWinnerInfoCommand> checkData = (roundWinnerInfo, cmd) => {
                Assert.AreEqual(roundID, roundWinnerInfo.RoundID, "RoundID");
                Assert.AreEqual(winnerHiNorAmount, roundWinnerInfo.WinnerHightNormalAmount, "WinnerHightNormalAmount");
                Assert.AreEqual(winnerHiNorCount, roundWinnerInfo.WinnerHightNormalCount, "WinnerHightNormalCount");
                Assert.AreEqual(winnerLoNorAmount, roundWinnerInfo.WinnerLowNormalAmount, "WinnerLowNormalAmount");
                Assert.AreEqual(winnerLoNorCount, roundWinnerInfo.WinnerLowNormalCount, "WinnerLowNormalCount");
                Assert.AreEqual(winnerHiCriAmount, roundWinnerInfo.WinnerHightCriticalAmount, "WinnerHightCriticalAmount");
                Assert.AreEqual(winnerHiCriCount, roundWinnerInfo.WinnerHightCriticalCount, "WinnerHightCriticalCount");
                Assert.AreEqual(winnerLoCriAmount, roundWinnerInfo.WinnerLowCriticalAmount, "WinnerLowCriticalAmount");
                Assert.AreEqual(winnerLoCriCount, roundWinnerInfo.WinnerLowCriticalCount, "WinnerLowCriticalCount");
            };

            Dac_UpdateRoundWinnerInfo.ApplyAction(new RoundWinnerInformation(), new UpdateRoundWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"\(Twowins_CalculateGameRoundWinner\)call CalculateGameRoundWinnerExecutor\(RoundID: '(.*)'\)")]
        public void WhenTwowins_CalculateGameRoundWinnerCallCalculateGameRoundWinnerExecutorRoundIDX(int roundID)
        {
            CalculateGameRoundWinnerCommand cmd = new CalculateGameRoundWinnerCommand { RoundID = roundID };
            CalculateGameRoundWinnerExecutor.Execute(cmd, (x) => { });
        }

        [When(@"\(Twowins_CalculateGameRoundWinner\)Expected exception and call CalculateGameRoundWinnerExecutor\(RoundID: '(.*)'\)")]
        public void WhenTwowins_CalculateGameRoundWinnerExpectedExceptionAndCallCalculateGameRoundWinnerExecutorRoundIDX(int roundID)
        {
            try {
                CalculateGameRoundWinnerCommand cmd = new CalculateGameRoundWinnerCommand { RoundID = roundID };
                CalculateGameRoundWinnerExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }
    }
}
