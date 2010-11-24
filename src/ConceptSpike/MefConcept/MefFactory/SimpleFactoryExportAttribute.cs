using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace MefFactory
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SimpleFactoryExportAttribute : ExportAttribute
    {
        public SimpleFactoryExportAttribute()
        {
        }

        public Type TargetType { get; set; }
    }
}
