using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace MefFactory
{
    public class SimpleFactory
    {
        [ImportMany]
        IEnumerable<Lazy<ExportClass, IFactoryMetadata>> Targets { get; set; }

        public T GetObject<T>()
            where T : ExportClass
        {
            return (T)Targets.Where(t => t.Metadata.TargetType.Equals(typeof(T))).Select(t => t.Value).FirstOrDefault();
        }
    }
}
