using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Infrastructure.LotUpdate.Specs.StatusTrackerSpecs.Steps
{
    [Binding]
    public class StatusTrackerSteps
    {
        private ILotRetrieverFactory _lotRetrieverFactory;
        private StatusTracker _statusTracker;
        private Uri _pollingUrl;
        private Dictionary<string, IEnumerable<TrackingInformation>> _dicLotData =
            new Dictionary<string, IEnumerable<TrackingInformation>>();
        private string _currentLotNo;

        private MockRepository _mocks;

        [Given(@"an instance of LotRetrieverFactory")]
        public void GivenAnInstanceOfLotRetrieverFactory()
        {
            _mocks = new MockRepository();
            _lotRetrieverFactory = _mocks.Stub<ILotRetrieverFactory>();
        }

        [Given(@"an instance of StatusTracker")]
        public void GivenAnInstanceOfStatusTracker()
        {
            _statusTracker = new StatusTracker();
        }

        [When(@"assign LotRetriverFactory to the property of the StatusTracker")]
        public void WhenAssignLotRetriverFactoryToThePropertyOfTheStatusTracker()
        {
            _statusTracker.LotRetrieverFactory = _lotRetrieverFactory;
        }

        [When(@"call StatusTracker\.Initialize\('(.*)'\)")]
        public void WhenCallStatusTracker_InitializeHttpLocalhostGetCurrentLotNo(string pollingUrl)
        {
            _pollingUrl = new Uri(pollingUrl, UriKind.RelativeOrAbsolute);
            _statusTracker.Initialize(_pollingUrl);
        }

        [Then(@"LotRetriverFactory\.PollingUrl should has the same value as the StatusTracker\.PollingUrl")]
        public void ThenLotRetriverFactory_PollingUrlShouldHasTheSameValueAsTheStatusTracker_PollingUrl()
        {
            Assert.AreEqual(_pollingUrl, _statusTracker.PollingUrl);
            Assert.AreEqual(_statusTracker.PollingUrl, _lotRetrieverFactory.PollingUrl);
        }

        [Then(@"StatusTracker\.LotRetriverFactory should be set correctly")]
        public void ThenStatusTracker_LotRetriverFactoryShouldBeSetCorrectly()
        {
            Assert.IsNotNull(_statusTracker.LotRetrieverFactory);
            Assert.AreSame(_lotRetrieverFactory, _statusTracker.LotRetrieverFactory);
        }


        [Given(@"tracking information of lot\# (.*) has data as shown in the table")]
        public void GivenTrackingInformationOfLot2003HasDataAsShownInTheTable(string lotNo, Table table)
        {
            List<TrackingInformation> lst = new List<TrackingInformation>();
            foreach (var row in table.Rows) {
                TrackingInformation info = new TrackingInformation {
                    TrackingID = Guid.Parse(row["TrackingID"]),
                    Status = row["Status"],
                    LotNo = lotNo,
                };
                lst.Add(info);
            }
            _dicLotData[lotNo] = lst;
        }

        [Given(@"a StatusTracker has been created and initialized")]
        public void GivenAStatusTrackerHasBeenCreatedAndInitialized()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"an instance of TrackingObserverBase derived class has been created")]
        public void GivenAnInstanceOfTrackingObserverBaseDerivedClassHasBeenCreated()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the server current lot\# is (.*)")]
        public void GivenTheServerCurrentLotIs2003(string lotNo)
        {
            _currentLotNo = lotNo;
        }

        [Then(@"OnUpdateTrackingInformation should be called with the tracking information \#(.*)")]
        public void ThenOnUpdateTrackingInformationShouldBeCalledWithTheTrackingInformation(string trackingID)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call TrackingObserverBase\.Initialize\(statusTracker\)")]
        public void WhenCallTrackingObserverBase_InitializeStatusTracker()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call TrackingObserverBase\.SetTrackingID\((.*)\)")]
        public void WhenCallTrackingObserverBase_SetTrackingID(string trackingID)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the server current lot\# is (.*)")]
        public void WhenTheServerCurrentLotIs2004(string lotNo)
        {
            _currentLotNo = lotNo;
        }
    }
}
