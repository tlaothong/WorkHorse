using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PerfEx.Demo.SimpleGame.DAL;

namespace PerfEx.Demo.SimpleGame.Specs.Steps {
    public class ColorGameServiceStepBase {
        protected ColorGameService ColorGS {
            get {
                return ScenarioContext.Current[
                    GameServiceCommonStep.Key_ColorGameService] as ColorGameService;
            }
        }

        protected IColorGameDataAccess Dac {
            get {
                return ScenarioContext.Current[
                    GameServiceCommonStep.Key_Dac] as IColorGameDataAccess;
            }
        }
    }
}
