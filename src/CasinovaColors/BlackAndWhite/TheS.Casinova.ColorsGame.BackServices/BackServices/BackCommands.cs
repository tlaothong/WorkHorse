using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure;

namespace TheS.Casinova.ColorsGame.BackServices
{
    public class BackCommands : PerfEx.Infrastructure.CommandPattern.CommandManagerBase
    {
        public static readonly BackCommands Manager = new BackCommands();

        protected BackCommands()
            : base(new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory())
        {
        }

        protected override void InitCommandRegistry(PerfEx.Infrastructure.CommandPattern.CommandExecutorRegistry registry)
        {
            RegisterReferenceExecutors(registry, "back");

            InitRegistry((PerfEx.Infrastructure.IDependencyRegistry)registry);
        }

        protected virtual void InitRegistry(PerfEx.Infrastructure.IDependencyRegistry registry)
        {
            DynamicDependencyRegistration.RegisterReferenceServiceObjectProviders(registry);
        }
    }
}
