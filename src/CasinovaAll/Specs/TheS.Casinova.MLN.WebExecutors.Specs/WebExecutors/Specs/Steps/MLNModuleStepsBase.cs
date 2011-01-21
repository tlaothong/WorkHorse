using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;
using TheS.Casinova.MLN.BackServices;
using TheS.Casinova.MLN.DAL;

namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class MLNModuleStepsBase
    {

        protected ICreateMLNInfo Dac_CreateMLNInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ICreateMLNInfo>();
            }
        }

        protected IListMLNInfo Dqr_ListMLNInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IListMLNInfo>();
            }
        }

        protected IListDownLineByLevel Dqr_ListDownLineByLevel        {
            get
            {
                return ScenarioContext.Current.Get<IListDownLineByLevel>();
            }
        }

        protected CreateMLNInfoExecutor CreateMLNInfo
        {
            get
            {
                return ScenarioContext.Current.Get<CreateMLNInfoExecutor>();
            }
        }

        protected ListMLNInfoExecutor ListMLNInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListMLNInfoExecutor>();
            }
        }

        protected ListDownLineByLevelExecutor ListDownLineByLevel
        {
            get
            {
                return ScenarioContext.Current.Get<ListDownLineByLevelExecutor>();
            }
        }
    }
}
