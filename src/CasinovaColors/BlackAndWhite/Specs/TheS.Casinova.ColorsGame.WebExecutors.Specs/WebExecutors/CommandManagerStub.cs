using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure;

namespace TheS.Casinova.ColorsGame.WebExecutors
{
    public class CommandManagerStub : PerfEx.Infrastructure.CommandPattern.CommandManagerBase
    {
        Type _xcutors = typeof(TheS.Casinova.ColorsGame.WebExecutors.PayForColorsWinnerInfoExecutor);

        private Action<PerfEx.Infrastructure.IDependencyRegistry> _registerAction;

        public CommandManagerStub(Action<PerfEx.Infrastructure.IDependencyRegistry> registerAction)
            : base(new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory())
        {
            _registerAction = registerAction;
        }

        protected override void InitCommandRegistry(PerfEx.Infrastructure.CommandPattern.CommandExecutorRegistry registry)
        {
            RegisterReferenceExecutors(registry, "web");

            InitRegistry((PerfEx.Infrastructure.IDependencyRegistry)registry);
        }

        protected virtual void InitRegistry(PerfEx.Infrastructure.IDependencyRegistry registry)
        {
            _registerAction(registry);
        }
    }
}