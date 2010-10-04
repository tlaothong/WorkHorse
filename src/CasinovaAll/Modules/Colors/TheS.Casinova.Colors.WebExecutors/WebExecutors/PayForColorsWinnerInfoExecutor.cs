using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.BackServices;

namespace TheS.Casinova.Colors.WebExecutors
{ 
    /// <summary>
    /// สร้าง TrackingID ส่งให้ client และส่ง command ไปยัง back server
    /// </summary>
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private IColorsGameBackService _dac;
       
        public PayForColorsWinnerInfoExecutor(IColorsGameBackService dac)
        {
            _dac = dac;
        }

        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            _dac.PayForWinnerInfo(command);
            //TODO: code for call web service
        } 
    }
}
