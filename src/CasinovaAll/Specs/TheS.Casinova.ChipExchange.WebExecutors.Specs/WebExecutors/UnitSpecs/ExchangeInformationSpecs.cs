﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Validators;
using TheS.Casinova.ChipExchange.DAL;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.ChipExchange.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ExchangeInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;

            setupValidators(out container,out svc);

            var model = new ExchangeInformation {
                UserName = null,
                AccountType = "Primary",
                Amount = 500,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            //IChipsExchangeModuleDataQuery dqr;

            setupValidators(out container, out svc);

            var model = new ExchangeInformation {
                UserName = "Nit",
                AccountType = "Primary",
                Amount = 0,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_AccountTypeCanNotBeNull()
        {
                IDependencyContainer container;
                IChipsExchangeModuleBackService svc;
                //IChipsExchangeModuleDataQuery dqr;

                setupValidators(out container, out svc);

                var model = new ExchangeInformation {
                    UserName = "Nit",
                    AccountType = "Primary",
                    Amount = 500,
                };
                var cmd = new MoneyToChipsCommand {
                    ExchangeInformation = model,
                };

                MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                    svc, container);
                xcutor.Execute(cmd, (xcmd) => { });

            //catch (ValidationErrorException ex) {
            //    foreach (var error in ex.Errors) {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //    throw;
            //}
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_AccountNoMustBeCorrect()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            //IChipsExchangeModuleDataQuery dqr;

            setupValidators(out container, out svc);

            var model = new ExchangeInformation {
                UserName = "Nit",
                AccountType = "Primary",
                Amount = 400,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IChipsExchangeModuleBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            MockRepository mocks = new MockRepository();
            IChipsExchangeModuleDataQuery dqr = mocks.DynamicMock<IChipsExchangeModuleDataQuery>();
            IGetPlayerAccountInfo getPlayerAccount = dqr;

            PlayerAccountInformation playerAccount = new PlayerAccountInformation {
                UserName = Convert.ToString("Nit"),
                AccountType = Convert.ToString("Primary"),
                CardType = Convert.ToString("Visa"),
                AccountNo = Convert.ToString("4111561111671111"),
                CVV = Convert.ToString("0532"),
                ExpireDate = DateTime.Parse("10/31/2010	"),
                Active = Convert.ToBoolean("true"),
                FirstName = Convert.ToString("Nittaya"),
                LastName = Convert.ToString("Lakchai")
            };

            SetupResult.For(getPlayerAccount.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments()
                .Return(playerAccount);

            reg.Register<IValidator<ExchangeInformation, NullCommand>
                , DataAnnotationValidator<ExchangeInformation, NullCommand>>();

            reg.Register<IValidator<ExchangeInformation, MoneyToChipsCommand>
               , ExchangeInformation_MoneyToChipsValidators>();

            reg.RegisterInstance<IChipsExchangeModuleDataQuery>
                (dqr);
            reg.Register<IServiceObjectProvider<IChipsExchangeModuleDataQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IChipsExchangeModuleDataQuery, IChipsExchangeModuleDataQuery>>();

            mocks.ReplayAll();
            container = fac.CreateContainer(reg);
            svc = mocks.DynamicMock<IChipsExchangeModuleBackService>();
            //dqr = null;        
        }
    }
}
