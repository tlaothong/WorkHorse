﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.BackServices;

namespace TheS.Casinova.TwoWins.WebExecutors
{ 
    /// <summary>
    /// สร้าง TrackingID ส่งให้ client และส่ง command ไปยัง back server
    /// </summary>
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private IPayForWinner _iPayForWinner;
       
        public PayForColorsWinnerInfoExecutor(IColorsGameBackService dac)
        {
            _iPayForWinner = dac;
        }

        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            _iPayForWinner.PayForWinnerInfo(command);
            //TODO: code for call web service
        } 
    }
}
