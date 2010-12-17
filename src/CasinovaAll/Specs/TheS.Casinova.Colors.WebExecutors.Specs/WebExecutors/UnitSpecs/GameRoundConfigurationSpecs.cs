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
    public class GameRoundConfigurationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGameRoundConfiguration_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = null,
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
        public void ValidateGameRoundConfiguration_NameMustStringLengthGreaterThan5()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More",
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
        public void ValidateGameRoundConfiguration_IntervalMustGreaterThan0()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
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
        public void ValidateGameRoundConfiguration_IntervalMustLessThan1440()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
                Interval = 1550,
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
        public void ValidateGameRoundConfiguration_GameDurationMustGreaterThan0()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
                Interval = 8,
                GameDuration = 0,
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
        public void ValidateGameRoundConfiguration_GameDurationMustLessThan1440()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
                Interval = 8,
                GameDuration = 1450,
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
        public void ValidateGameRoundConfiguration_TableAmountMustGreaterThan0()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
                Interval = 8,
                GameDuration = 30,
                TableAmount = 0,
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
        public void ValidateGameRoundConfiguration_TableAmountMustLessThan99()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "More than 5 letters",
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
        public void ValidateGameRoundConfiguration_BufferRoundCountMustGreaterThan0()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "Morethan 5 letters",
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

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGameRoundConfigurationr_BufferRoundCountMustLessThan99()
        {
            IDependencyContainer container;
            IGameTableBackService svc;
            setupValidators(out container, out svc);

            var model = new GameRoundConfiguration {
                ConfigName = "Morethan 5 letters",
                Interval = 20,
                GameDuration = 30,
                TableAmount = 500,
                BufferRoundsCount = 100
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
                , GameRoundConfiguration_CreateGameRoundConfigurationValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
