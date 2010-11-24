using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ColorsGame.ColorsGameSvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ColorsGame.Specs.Steps
{
    [Binding]
    public class CheckGamePlayInfoStep : CheckGamePlayInfoStepBase
    {
        private Guid _expectedTrackingID;   //OnGoingTrackingID
        private int _tableID, _roundID;
        private Guid _trackingID;
        private IEnumerable<GamePlayInformation> _result;


        [Given(@"Game Play Information on BackServer as:")]
        public void GivenGamePlayInformationOnBackServerAs(Table table)
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

            SetupResult.For(Dac.GetMyGamePlayInfo()).Return(qry.ToArray());

        }

        [Given(@"TrackingID = '(.*)' from Table = '(.*)' RoundID = '(.*)'")]
        public void GivenTrackingID625604D9_082A_4C58_A7FC_3023A4EC1430FromTable1RoundID1(string trackingID,int tableID,int roundID)
        {
            _trackingID = Guid.Parse(trackingID);
            _tableID = tableID;
            _roundID = roundID;
        }

        
        [When(@"I receive GamePlayInformation\[]")]
        public void WhenIReceiveGamePlayInformation()
        {
            _result = Dac.GetMyGamePlayInfo();
        }

        [Then(@"the result will be accept by OnGoingTrackingID: '(.*)'")]
        public void ThenTheResultWillBeAccept(string onGoingTracking)
        {
            _expectedTrackingID = Guid.Parse(onGoingTracking);
            var resul = _result.FirstOrDefault(c => c.TableID.Equals(_tableID) && c.RoundID.Equals(_roundID));
            Assert.AreEqual(_expectedTrackingID, resul.TrackingID);
        }

        [Then(@"request GamePlayInformation again")]
        public void ThenRequestGamePlayInformation()
        {
            //Process is not complete
            //Request GamePlayInformation from server again
        }

    }
}
