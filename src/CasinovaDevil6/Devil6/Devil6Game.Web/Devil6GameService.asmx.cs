using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Devil6Game.Web
{
    /// <summary>
    /// Summary description for Devil6GameService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Devil6GameService : System.Web.Services.WebService
    {
        private const double MaximumRoom6 = 6;
        private const double MaximumRoom66 = 66;
        private const double MaximumRoom666 = 666;
        private const double MaximumRoom6666 = 6666;

        private static double _potRoom6;
        private static double _potRoom66;
        private static double _potRoom666;
        private static double _potRoom6666;

        [WebMethod]
        public double BetRoom6(double value)
        {
            _potRoom6 += value;
            double currentBet = _potRoom6;
            if (_potRoom6 >= MaximumRoom6) {
                _potRoom6 = 0;
                currentBet = MaximumRoom6;
            }
            return currentBet;
        }

        [WebMethod]
        public double BetRoom66(double value)
        {
            _potRoom66 += value;
            double currentBet = _potRoom66;
            if (_potRoom66 >= MaximumRoom66) {
                _potRoom66 = 0;
                currentBet = MaximumRoom66;
            }
            return currentBet;
        }

        [WebMethod]
        public double BetRoom666(double value)
        {
            _potRoom666 += value;
            double currentBet = _potRoom666;
            if (_potRoom666 >= MaximumRoom666) {
                _potRoom666 = 0;
                currentBet = MaximumRoom666;
            }
            return currentBet;
        }

        [WebMethod]
        public double BetRoom6666(double value)
        {
            _potRoom6666 += value;
            double currentBet = _potRoom6666;
            if (_potRoom6666 >= MaximumRoom6666) {
                _potRoom6666 = 0;
                currentBet = MaximumRoom6666;
            }
            return currentBet;
        }
    }
}
