using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices.Validators;
using TheS.Casinova.Colors.BackServices.BackExecutors;
using TheS.Casinova.Colors.DAL;
using Rhino.Mocks;

namespace TheS.Casinova.Colors.BackServices.UnitSpecs
{
    [TestClass]
    public class BetColorExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetColorExecutor_ActionTypeShouldBeBetweenBlackOrWhite()
        {
            //IDependencyContainer container;
            //IColorsGameDataAccess dac;
            //IColorsGameDataBackQuery dqr;
            //setupValidators(out container, out dac, out dqr);

            //BetCommand cmd = new BetCommand{
            //    PlayerActionInformation = new Models.PlayerActionInformation
            //    {
            //        UserName = "OhAe",
            //        RoundID = 12,
            //        Amount = 78,
            //        ActionType = "Red",
            //        TrackingID = Guid.Parse("B21F8971-DBAB-400F-9D95-151BA24875C1"),
            //    },
            //};

            //BetColorExecutor executor = new BetColorExecutor(container, dac, dqr);
            //executor.Execute(cmd, (x) => { });
        }


        //private static void setupValidators(out IDependencyContainer container, out IColorsGameDataAccess dac, out IColorsGameDataBackQuery dqr)
        //{

           //var fac = new StructureMapAbstractFactory();
           // var reg = fac.CreateRegistry();

           // reg.Register<IValidator<UserProfile, BetCommand>
           //     , UserProfile_BetColorValidator>();
            
           // container = fac.CreateContainer(reg);
           // dac = null;
           // dqr = null;
        //}
    }
}
