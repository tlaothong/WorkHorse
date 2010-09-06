using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Demo.SystemUnderTest
{
    public interface IWorkTogether
    {
        string ReadText();
        int NumberOfFans { get; }
        string NumToText(int number);
    }
}
