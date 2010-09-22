using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class GameTableConfigurationRelatedCommandBase
    {
        public string Name { get; set; }
        public IEnumerable<TableConfiguration> TableConfigurations { get; set; }
    }
}
