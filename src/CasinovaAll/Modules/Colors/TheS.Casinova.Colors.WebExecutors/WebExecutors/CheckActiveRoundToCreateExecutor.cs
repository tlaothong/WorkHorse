using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.WebExecutors
{
   public class CheckActiveRoundToCreateExecutor
     : SynchronousCommandExecutorBase<CheckActiveRoundToCreateCommand>
    {
       private ICheckActiveRoundToCreate _iCheck;
       private IListActiveGameRounds _iListActiveRound;
       private IGetGameRoundConfigurations _iGetGameRoundConfig;
       private GetGameRoundConfigurationsCommand _getRoundInfo;
       private ListActiveGameRoundsCommand _listActive;
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
           _listActive = new ListActiveGameRoundsCommand();
           _getRoundInfo = new GetGameRoundConfigurationsCommand();

           //ดึงข้อมูลการ config จากการสร้างจำนวนโต๊ะเกม
           _getRoundInfo.Name = command.Name;
           _getRoundInfo.GameRoundConfigInfo = _iGetGameRoundConfig.Get(_getRoundInfo);
 
           
           //List โต๊ะเกมทั้งหมดที่กำลัง active
           _listActive.FromTime = DateTime.Now;
           _listActive.ActiveRounds = _iListActiveRound.List(_listActive);

           _activeRoundCount = _listActive.ActiveRounds.Count();
           _sumActiveRound = _getRoundInfo.GameRoundConfigInfo.BufferRoundsCount + _getRoundInfo.GameRoundConfigInfo.TableAmount;

           //ตรวจสอบจำนวน round ที่กำลัง active เพื่อสร้าง ActiveRound เพิ่ม
           if (_activeRoundCount < _sumActiveRound) 
           {
               _iCheck.Check(command);
           }
       }
    }
}
