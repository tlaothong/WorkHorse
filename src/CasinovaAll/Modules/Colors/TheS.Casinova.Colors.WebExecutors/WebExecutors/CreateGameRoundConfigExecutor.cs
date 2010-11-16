using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// สร้าง active round
    /// </summary>
    public class CreateGameRoundConfigExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundConfigurationCommand>
    {
        private ICreateGameTableConfigurations _iCreateRoundConfig;
        private IDependencyContainer _container;
        public CreateGameRoundConfigExecutor(IGameTableBackService dac, IDependencyContainer container)
        {
            _iCreateRoundConfig = dac;
            _container = container;
        }
 
        protected override void ExecuteCommand(CreateGameRoundConfigurationCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.GameRoundConfig, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            _iCreateRoundConfig.Create(command);
        }
    }
}
