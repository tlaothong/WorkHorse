﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class GetGamePlayInfoCommand
    {
        public string UserName { get; set; }

        public IEnumerable<GamePlayInformation> GamePlayInfos { get; set; }
    }
}