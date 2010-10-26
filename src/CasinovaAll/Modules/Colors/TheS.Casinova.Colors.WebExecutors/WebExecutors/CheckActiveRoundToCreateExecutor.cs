using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ตรวจสอบจำนวน active round
    /// </summary>
   public class CheckActiveRoundToCreateExecutor
     : SynchronousCommandExecutorBase<CheckActiveRoundToCreateCommand>
    {
       private ICheckActiveRoundToCreate _iCheck;
       private IListActiveGameRounds _iListActiveRound;
       private IGetGameRoundConfigurations _iGetGameRoundConfig;
       private GetGameRoundConfigurationCommand _getRoundInfo;
       private ListActiveGameRoundCommand _listActive;
       private int _activeRoundCount;           //จำนวน ActiveRound ที่มีอยู่ในขณะนั้น
       private int _sumActiveRound;             //จำนวน ActiveRound ทั้งหมดที่ต้องมี

       public CheckActiveRoundToCreateExecutor(IGameTableBackService dac, IColorsGameDataQuery dqr) 
       {
           _iCheck = dac;
           _iListActiveRound = dqr;
           _iGetGameRoundConfig = dqr;
       }

       protected override void ExecuteCommand(CheckActiveRoundToCreateCommand command)
       {
           _listActive = new ListActiveGameRoundCommand();
           _getRoundInfo = new GetGameRoundConfigurationCommand();

           //ดึงข้อมูลการ config จากการสร้างจำนวนโต๊ะเกม
           _getRoundInfo.Name = command.Name;
           _getRoundInfo.GameRoundConfiguration = _iGetGameRoundConfig.Get(_getRoundInfo);
 
           
           //List โต๊ะเกมทั้งหมดที่กำลัง active
           _listActive.FromTime = DateTime.Now;
           _listActive.ActiveRounds = _iListActiveRound.List(_listActive);

           _activeRoundCount = _listActive.ActiveRounds.Count();
           _sumActiveRound = _getRoundInfo.GameRoundConfiguration.BufferRoundsCount + _getRoundInfo.GameRoundConfiguration.TableAmount;

           //ตรวจสอบจำนวน round ที่กำลัง active เพื่อสร้าง ActiveRound เพิ่ม
           if (_activeRoundCount < _sumActiveRound) 
           {
               _iCheck.Check(command);
           }
       }
    }
}
