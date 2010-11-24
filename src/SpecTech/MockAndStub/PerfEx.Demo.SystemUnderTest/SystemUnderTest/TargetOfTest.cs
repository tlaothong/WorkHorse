using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Demo.SystemUnderTest
{
    public class TargetOfTest
    {
        #region properties

        private IWorkTogether _workTogether;

        public IWorkTogether WorkTogether
        {
            get { return _workTogether; }
            set { _workTogether = value; }
        }

        private IMembership _member;

        public IMembership Member
        {
            get { return _member; }
            set { _member = value; }
        }

        #endregion properties

        public string Hello()
        {
            _workTogether.Log("Hello");
            string name = _workTogether.ReadText();
            return string.Format("Hello {0}. How are you?", name);
        }

        public int HowManyFans()
        {
            _workTogether.Log("HowManyFans");
            return _workTogether.NumberOfFans;
        }

        public string HowManyFansInText()
        {
            _workTogether.Log("HowManyFansInText");
            int noOfFans = _workTogether.NumberOfFans;
            string textOfNo = _workTogether.NumToText(noOfFans);

            return string.Format("There is/are {0} fan(s).", textOfNo);
        }

        public string HelloStudent(int studentId)
        {
            _workTogether.Log("HelloStudent");
            string name = _workTogether.GetStudentName(studentId);

            if (!string.IsNullOrEmpty(name)) {
                _workTogether.Log("Found: " + name);
                return string.Format("Hello {0}.", name);
            }
            else {
                _workTogether.Log("Not found!");
                return string.Format(
                    "There's no student with id# {0}", studentId);
            }
        }

        public string AddToText(int a, int b)
        {
            int result = _workTogether.Add(a, b);
            return _workTogether.NumToText(result);
        }

        public string HelloUser()
        {
            var userName = _member.User.Identity.Name;
            return string.Format("Hello {0}.", userName);
        }
    }
}
