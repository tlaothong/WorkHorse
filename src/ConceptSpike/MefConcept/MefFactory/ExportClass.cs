﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace MefFactory
{
    [SimpleFactoryExport(TargetType = typeof(ExportClass))]
    public class ExportClass
    {
    }
}
