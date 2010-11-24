using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace MefFactory
{
    public class SimpleImport
    {
        [Import]
        public ExportClass Target { get; set; }
    }
}
