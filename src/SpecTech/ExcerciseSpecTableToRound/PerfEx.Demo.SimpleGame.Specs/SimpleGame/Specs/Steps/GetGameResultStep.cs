using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PerfEx.Demo.SimpleGame.DAL;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SimpleGame.Specs.Steps {
    [Binding]
    public class GetGameResultStep : ColorGameServiceStepBase{

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
        private GameResult _result;


        private int _tableID;
        private int _roundID;

        [Given(@"server has game information as:")]
        public void GivenServerHasGameInformationAs(Table table) {
            GameResult qry;
            if (table.RowCount <1) {
                qry = null;

            } else {
                qry = new GameResult {
                    TotalAmountOfBlack = Convert.ToInt32(table.Rows[0]["TotalAmountOfBlack"]),
                    TotalAmountOfWhite = Convert.ToInt32(table.Rows[0]["TotalAmountOfWhite"]),
                    HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
                };
            }

            SetupResult.For(Dac.Get(new Commands.GetGameResultCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [Given(@"I have entered TableID (.*) and RoundID (.*)")]
        public void GivenIHaveEnteredTableID1AndRoundID1(int tableID,int roundID) {
            _tableID = tableID;
            _roundID = roundID;
        }

        [When(@"I press getting process")]
        public void WhenIPressGettingProcess() {
            _result = ColorGS.GetGameResult(_tableID, _roundID);
        }

        [Then(@"the game result should be")]
        public void ThenTheGameResultShouldBe(Table table) {

            GameResult expected = new GameResult {
                    TotalAmountOfBlack = Convert.ToInt32(table.Rows[0]["TotalAmountOfBlack"]),
                    TotalAmountOfWhite = Convert.ToInt32(table.Rows[0]["TotalAmountOfWhite"]),
                    HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
                };

            Assert.AreEqual(expected.TotalAmountOfBlack, _result.TotalAmountOfBlack, "TotalAmountOfBlack");
            Assert.AreEqual(expected.TotalAmountOfWhite, _result.TotalAmountOfWhite, "TotalAmountOfWhite");
            Assert.AreEqual(expected.HandCount, _result.HandCount, "HandCount");
        }

        [Then(@"the game result should be null")]
        public void ThenTheGameResultShouldBeNull() {
            //Assert.AreEqual(null, _result);
            Assert.IsNull(_result);
           
        }

    }
}
