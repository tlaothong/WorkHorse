using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoSpecFlow.Specs
{
    [Binding]
    public class NameMessageSteps
    {
        private ViewModels.MainPageViewModel _sut = new ViewModels.MainPageViewModel(); // view model to test
        private string _propName;

        [Given(@"I have entered name '(.*)'")]
        public void GivenIHaveEnteredNameJohn(string name)
        {
            _sut.Name = name;
        }

        [Given(@"I registered to PropertyChanged")]
        public void GivenIRegisteredToPropertyChanged()
        {
            _sut.PropertyChanged += (sender, e) => {
                _propName = e.PropertyName;
            };
        }

        [When(@"I press Submit")]
        public void WhenIPressSubmit()
        {
            _sut.Submit();
        }

        [Then(@"the result should be '(.*)' on the screen")]
        public void ThenTheResultShouldBeHelloJohn_OnTheScreen(string message)
        {
            Assert.AreEqual(message, _sut.Message);
        }

        [Then(@"the notification should be raised for (.*)")]
        public void ThenTheNotificationShouldBeRaisedForName(string propName)
        {
            Assert.IsNotNull(_propName);
            Assert.AreEqual(propName, _propName);
        }
    }
}
