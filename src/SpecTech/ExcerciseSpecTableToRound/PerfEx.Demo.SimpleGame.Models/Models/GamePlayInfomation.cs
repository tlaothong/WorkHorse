using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Demo.SimpleGame.Models {
    public class GamePlayInfomation {

        public int TableID { get; set; }
        public int RoundID { get; set; }
        public int TotalBetAmountOfBlack { get; set; }
        public int TotalBetAmountOfWhite { get; set; }
        public DateTime  LastUpdate { get; set; }
        public string  TrackingID { get; set; }
        public string OnGoingTrackingID { get; set; }
        public string Winner { get; set; }
    }
}
