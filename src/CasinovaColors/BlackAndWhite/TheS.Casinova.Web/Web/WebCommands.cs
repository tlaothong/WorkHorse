using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure;

namespace TheS.Casinova.Web
{
    public class WebCommands : PerfEx.Infrastructure.CommandPattern.CommandManagerBase
    {
        public static readonly WebCommands Manager = new WebCommands();

        protected WebCommands()
            : base(new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory())
        {
        }

        protected override void InitCommandRegistry(PerfEx.Infrastructure.CommandPattern.CommandExecutorRegistry registry)
        {
            RegisterReferenceExecutors(registry, "web");

            InitRegistry((PerfEx.Infrastructure.IDependencyRegistry)registry);
        }

        protected virtual void InitRegistry(PerfEx.Infrastructure.IDependencyRegistry registry)
        {
            DynamicDependencyRegistration.RegisterReferenceServiceObjectProviders(registry);
        }
    }
}
