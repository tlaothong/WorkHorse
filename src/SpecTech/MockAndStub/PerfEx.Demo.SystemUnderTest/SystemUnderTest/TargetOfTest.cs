using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Demo.SystemUnderTest
{
    public class TargetOfTest
    {
        private IWorkTogether _workTogether;

        public IWorkTogether WorkTogether
        {
            get { return _workTogether; }
            set { _workTogether = value; }
        }

        public string Hello()
        {
            string name = _workTogether.ReadText();
            return string.Format("Hello {0}. How are you?", name);
        }

        public int HowManyFans()
        {
            return _workTogether.NumberOfFans;
        }
    }
}
