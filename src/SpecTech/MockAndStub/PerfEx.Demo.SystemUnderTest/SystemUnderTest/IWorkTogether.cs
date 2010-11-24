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
        string GetStudentName(int studentId);

        void Log(string logMessage);

        int Add(int a, int b);  // Func<int, int, int>
    }
}
