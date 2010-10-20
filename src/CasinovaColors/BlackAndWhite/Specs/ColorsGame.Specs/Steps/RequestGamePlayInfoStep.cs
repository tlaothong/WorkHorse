using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsGame.ColorsGameSvc;

namespace ColorsGame.Specs.Steps {
    [Binding]
    public class RequestGamePlayInfoStep : RequestGamePlayInfoStepBase
    {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
        private Guid _trackingID;
        private int _tableID;
        private int _roundID;

        [Given(@"Game Play Information on BackServer is:")]
        public void GivenGamePlayInformationOnBackServerIs(Table table)
        {
            var qry = (from it in table.Rows
                       select new GamePlayInformation
                       {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TrackingID = Guid.Parse(it["TrackingID"]),
                           OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                           UserName = it["UserName"],
                           Winner = it["Winner"]
                       });

            Func<int, int, string> WhatTrackingID = (tableID, roundID) =>
            {
                var qry2 = (from it in qry
                            where it.TableID == tableID && it.RoundID == roundID
                            select it.TrackingID).FirstOrDefault().ToString();
                if (qry2.Any())
                    return qry2;
                else
                    return null; //สมมตินะ
            };

            SetupResult.For(Dac.GetMyGamePlayInfo()).Return((from it in qry
                                                             where it.TableID == _tableID && it.RoundID == _roundID
                                                             select it).ToArray());
            
            Expect.Call(Dac.PayForWinnerInformation(_tableID, _roundID))
                .IgnoreArguments()
                .Do(WhatTrackingID);
        }

        [Given(@"I have call PayForWinnerInformation\(tableID='(.*)',roundID='(.*)'\)")]
        public void GivenIHaveCallPayForWinnerInformationTableID1RoundID1(int tableID, int roundID)
        {
            _tableID = tableID;
            _roundID = roundID;

        }

        [When(@"recieve TrackingID from called")]
        public void WhenRecieveTrackingIDFromCalled()
        {

            _trackingID = Guid.Parse(Dac.PayForWinnerInformation(_tableID, _roundID));

        }

        [When(@"had not recieved TrackingID from called")]
        public void WhenHadNotRecievedTrackingIDFromCalled()
        {
            _trackingID = Guid.Parse(Dac.PayForWinnerInformation(_tableID, _roundID));
        }

        [Then(@"recall PayForWinnerInformation again")]
        public void ThenRecallPayForWinnerInformationAgain()
        {
  
        }

        [Then(@"I will receive trackingID then execute GetGamePlayInformation")]
        public void ThenExecuteGetGamePlayInformation()
        {
            Assert.IsNotNull(_trackingID);
        }
    }
}
