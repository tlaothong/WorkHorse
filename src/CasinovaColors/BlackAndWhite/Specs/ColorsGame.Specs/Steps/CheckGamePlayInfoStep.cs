using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ColorsGame.ColorsGameSvc;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorsGame.Specs.Steps {
    [Binding]
    public class CheckGamePlayInfoStep :CheckGamePlayInfoStepBase{

        private Guid _trackingID;
        private int _tableID;
        private int _roundID;
        private IEnumerable<GamePlayInformation> _expected;
        private IEnumerable<GamePlayInformation> _result;
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"Game Play Information on BackServer as:")]
        public void GivenGamePlayInformationOnBackServerAs(Table table) {
            var qry = (from it in table.Rows
                       select new GamePlayInformation {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TrackingID = Guid.Parse(it["TrackingID"]),
                           OnGoingTrackingID = Guid.Parse(it["OngoingTrackingID"]),
                           UserName = it["UserName"],
                           Winner = it["Winner"]
                       });

            _expected = (from it in qry
                         where (it.TableID == _tableID) && (it.RoundID == _roundID)
                         select new GamePlayInformation {
                             TableID = it.TableID,
                             RoundID = it.RoundID,
                             TrackingID = it.TrackingID,
                             OnGoingTrackingID = it.OnGoingTrackingID,
                             UserName = it.UserName,
                             Winner = it.Winner
                         });

            Func<int, int, IEnumerable<GamePlayInformation>> check = (tableId, roundId) => {
                return qry.Where(x => (x.TableID == tableId) && (x.RoundID == roundId));
            };

            //SetupResult.For(Dac.GetMyGamePlayInfo()).IgnoreArguments().Do(check);
            //SetupResult.For(Dac.GetMyGamePlayInfo()).IgnoreArguments().Return(_expected.ToArray());

        }

        [Given(@"TrackingID = '(.*)' from Table = '(.*)' RoundID = '(.*)'")]
        public void GivenTrackingID625604D9_082A_4C58_A7FC_3023A4EC1430FromTable1RoundID1(string trackingID, int tableID, int roundID) {
            _trackingID = Guid.Parse(trackingID);
            _tableID = tableID;
            _roundID = roundID;

        }

        [Then(@"the result will be accept")]
        public void ThenTheResultWillBeAccept() {
            var trackingResult = (from r in _result
                                  select r.TrackingID).FirstOrDefault();
            var trackingExpected = (from e in _expected
                                    select e.TrackingID).FirstOrDefault();

            Assert.AreEqual(trackingExpected, trackingResult);
        }

        [When(@"I receive GamePlayInformation\[]")]
        public void WhenIReceiveGamePlayInformation() {
            _result = Dac.GetMyGamePlayInfo();
        }
    }
}
