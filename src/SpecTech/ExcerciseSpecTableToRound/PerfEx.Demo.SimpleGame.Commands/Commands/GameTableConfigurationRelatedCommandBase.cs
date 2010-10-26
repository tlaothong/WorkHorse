using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;

namespace PerfEx.Demo.SimpleGame.Commands
{
    public class GameTableConfigurationRelatedCommandBase
    {
        public string Name { get; set; }
        public IEnumerable<GameTable> Tables { get; set; }
    }
}
