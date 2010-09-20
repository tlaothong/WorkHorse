using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class SaveTableConfigurationCommand
    {
        public string Name { get; set; }
        public IEnumerable<TableConfig> TableConfig { get; set; }
    }
}
