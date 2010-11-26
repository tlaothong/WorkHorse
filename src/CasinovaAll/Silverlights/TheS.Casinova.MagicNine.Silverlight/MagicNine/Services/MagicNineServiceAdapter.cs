using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TheS.Casinova.MagicNine.Services
{
    public class MagicNineServiceAdapter : IMagicNineServiceAdapter
    {
        #region IMagicNineServiceAdapter Members

        public IObservable<MagicNineSvc.ListActiveGameRoundInfoCommand> GetListActiveGameRound()
        {
            // TODO: MagicNineServiceAdapter GetListActiveGameRound
            throw new NotImplementedException();
        }

        public IObservable<MagicNineSvc.ListGamePlayAutoBetInfoCommand> GetListGamePlayAutoBetInformation(MagicNineSvc.ListGamePlayAutoBetInfoCommand cmd)
        {
            // TODO: MagicNineServiceAdapter GetListGamePlayAutoBetInformation
            throw new NotImplementedException();
        }

        public IObservable<MagicNineSvc.ListBetLogCommand> GetListBetLog(MagicNineSvc.ListBetLogCommand cmd)
        {
            // TODO: MagicNineServiceAdapter GetListBetLog
            throw new NotImplementedException();
        }

        public IObservable<MagicNineSvc.SingleBetCommand> BetSingle(MagicNineSvc.SingleBetCommand cmd)
        {
            // TODO: MagicNineServiceAdapter BetSingle
            throw new NotImplementedException();
        }

        public IObservable<MagicNineSvc.StartAutoBetCommand> AutoBetOn(MagicNineSvc.StartAutoBetCommand cmd)
        {
            // TODO: MagicNineServiceAdapter AutoBetOn
            throw new NotImplementedException();
        }

        public IObservable<MagicNineSvc.StopAutoBetCommand> AutoBetOff(MagicNineSvc.StopAutoBetCommand cmd)
        {
            // TODO: MagicNineServiceAdapter AutoBetOff
            throw new NotImplementedException();
        }

        #endregion
    }
}
