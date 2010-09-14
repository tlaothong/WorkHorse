using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;
using PerfEx.Demo.SimpleGame.DAL;
using PerfEx.Demo.SimpleGame.Commands;

namespace PerfEx.Demo.SimpleGame
{
    public class GameTableConfigurator
    {
        private IGameTableDataAccess _dac;

        public GameTableConfigurator(IGameTableDataAccess dac)
        {
            _dac = dac;
        }

        /// <summary>
        /// สร้าง GameTable เริ่มต้นจากค่าที่กำหนด
        /// </summary>
        /// <param name="tableCount">จำนวนโต๊ะที่เล่นได้พร้อมกัน</param>
        /// <param name="gameDuration">ระยะเวลาในการเล่นของแต่ละโต๊ะ</param>
        /// <param name="gameInterval">ระยะห่างระหว่างการเริ่มเกมของโต๊ะ</param>
        /// <returns>โต๊ะที่สร้างจากเงื่อนไขที่กำหนด</returns>
        public IEnumerable<GameTable> GenerateTableConfiguration(int tableCount, int gameDuration, int gameInterval)
        {
            for (int i = 0; i < tableCount; i++) {
                yield return new GameTable {
                    GameDuration = gameDuration,
                    Interval = gameInterval
                };
            }
        }

        /// <summary>
        /// บันทึกการตั้งค่าของโต๊ะ
        /// </summary>
        /// <param name="name">ชื่อ setting</param>
        /// <param name="tables">การตั้งค่าของโต๊ะต่าง ๆ</param>
        public void SaveTableConfiguration(string name, IEnumerable<GameTable> tables)
        {
            _dac.Create(new Commands.CreateGameTableConfigurationsCommand {
                Name = name,
                Tables = tables,
            });
        }

        /// <summary>
        /// สร้าง GameRound จาก setting โดยการระบุชื่อ ให้จำนวนของ GameRound ที่เล่นได้เต็มจำนวนโต๊ะและเพิ่มไปเท่าที่กำหนด
        /// </summary>
        /// <param name="name">ชื่อ setting</param>
        /// <param name="bufferRoundsCount">จำนวนโต๊ะที่สร้างให้เกินจากที่บันทึกไว้</param>
        public void CreateGameRounds(string name, int bufferRoundsCount)
        {
            CreateGameRoundCommand cmd = new CreateGameRoundCommand();
            var lstTable = _dac.List(new Commands.ListGameTableConfigurationsCommand {
                    Name = name,
            });
            var lstActiveRound = _dac.List(new Commands.ListActiveGameRoundsCommand {
                FromTime =new DateTime(2010,9,8,10,00,00)
            });

            //Find amount Round that must create
            int nOfRoundToCreate = lstTable.Count() - lstActiveRound.Count()+bufferRoundsCount;

            //Find last ActiveRound item
            GameRound lastActiveItem = lstActiveRound.LastOrDefault();
       
            GameTable tableData = (from it in lstTable
                                   where it.TableID == lastActiveItem.TableID
                                   select it).FirstOrDefault();
            //Action updateTableData = () => {
            //    tableData = (from it in lstTable
            //                 where it.TableID == lastActiveItem.TableID
            //                 select it).FirstOrDefault();
            //};
            GameRound nextRound;
            //Create Round
            for (int i = 0; i < nOfRoundToCreate; i++) {

                //Setup
                lastActiveItem.StartTime = lastActiveItem.StartTime.AddMinutes(tableData.Interval);
                lastActiveItem.EndTime = lastActiveItem.StartTime.AddMinutes(tableData.GameDuration);
                lastActiveItem.RoundID += 1;
                lastActiveItem.TableID += 1;
                
                nextRound = new GameRound {
                    TableID = lastActiveItem.TableID,
                    RoundID = lastActiveItem.RoundID,
                    StartTime = lastActiveItem.StartTime,
                    EndTime = lastActiveItem.EndTime,
                };
                _dac.Create(nextRound,cmd);
                if (nextRound.TableID == lstTable.Count()) {
                    lastActiveItem.TableID = 0;
                }
            }
            
            
            
        }

        /// <summary>
        /// ดึงข้อมูลโต๊ะเกมของผู้เล่นที่เล่นไว้ และเกมยังไม่จบ
        /// </summary>
        /// <param name="UserName">ชื่อของผู้เล่น</param>
        /// <returns>ข้อมูลของโต๊ะเกมที่ผู้เล่นเล่นอยู่</returns>
        public IEnumerable<GamePlayInfomation> GetGamePlayInformationForUser(string UserName) {
            DateTime _gameTime = new DateTime(2010, 9, 8, 10, 00, 00);

            //List gamePlayInformation
            var lstGamePlayInfo = _dac.List(new Commands.ListGamePlayInformationCommand { 
                FromTime = _gameTime,
                Username = UserName,
            });

            return lstGamePlayInfo.ToArray();




        }
    }
}
