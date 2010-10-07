using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using MefFactory.RealConcepts;

namespace MefFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //var catalog = new DirectoryCatalog(@".\");
            var catalog = new AssemblyCatalog(typeof(Program).Assembly);
            var container = new CompositionContainer(catalog);
            //var si = new SimpleImport();
            //container.ComposeParts(si);
            //Console.WriteLine(si.Target);

            //var fac = new SimpleFactory();
            //container.ComposeParts(fac);
            //Console.WriteLine(fac.GetObject<ExportClass>());

            var msop = new MefServiceObjectProvider<ExportClass, ExportClass>(container);
            Console.WriteLine(msop.ServiceProxy);
        }
    }
}
