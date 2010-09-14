using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;

namespace PerfEx.Demo.SimpleGame.Commands {
    public class ListGamePlayInformationCommand {
        //input
        public string  Username { get; set; }
        public DateTime FromTime { get; set; }

        //output
        public IEnumerable<GamePlayInfomation> GamePlayInfo { get; set; }
    }
}
