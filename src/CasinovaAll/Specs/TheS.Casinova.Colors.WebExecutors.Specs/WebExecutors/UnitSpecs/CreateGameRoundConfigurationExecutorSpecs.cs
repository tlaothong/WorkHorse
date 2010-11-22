using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.UnitSpecs
{
    using TheS.Casinova.Colors.Validators;
    using PerfEx.Infrastructure;
    using TheS.Casinova.Colors.BackServices;
    using TheS.Casinova.Colors.Models;
    using TheS.Casinova.Colors.Commands;
    using PerfEx.Infrastructure.Validation;
    using PerfEx.Infrastructure.CommandPattern;

    [TestClass]
    public class CreateGameRoundConfigurationExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = null,
                Interval = 20,
                GameDuration = 30,
                TableAmount = 50,
                BufferRoundsCount = 5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            //try {
                xcutor.Execute(cmd, (xcmd) => { });
            //}
            //catch (ValidationErrorException ex) {
            //    foreach (var err in ex.Errors) {
            //        Console.WriteLine(err);
            //    }
            //    throw;
            //}
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_NameMustStringLengthGreaterThan5()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = "More",
                Interval = 10,
                GameDuration = 30,
                TableAmount = 50,
                BufferRoundsCount = 5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_IntervalMustGreaterThan0AndLessThan1440()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = "More than 5 letters",
                Interval = -5,
                GameDuration = 30,
                TableAmount = 50,
                BufferRoundsCount = 5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_GameDurationMustGreaterThan0AndLessThan1440()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = "More than 5 letters",
                Interval = 8,
                GameDuration = 1550,
                TableAmount = 50,
                BufferRoundsCount = 5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_TableAmountMustGreaterThan0AndLessThan99()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = "More than 5 letters",
                Interval = 8,
                GameDuration = 30,
                TableAmount = 500,
                BufferRoundsCount = 5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateGameRoundConfigurationExecutor_BufferRoundCountMustGreaterThan0AndLessThan99()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                TableName = "Morethan 5 letters",
                Interval = 20,
                GameDuration = 30,
                TableAmount = 500,
                BufferRoundsCount = -5
            };
            var cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = model,
            };

            CreateGameRoundConfigExecutor xcutor = new CreateGameRoundConfigExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IGameTableBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GameRoundConfiguration, NullCommand>
                , DataAnnotationValidator<GameRoundConfiguration, NullCommand>>();
            reg.Register<IValidator<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
                , GameRoundConfiguration_CreateGameRoundConfigurationValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
