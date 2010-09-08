using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;

namespace PerfEx.Demo.SimpleGame
{
    public class GameTableConfigurator
    {
        /// <summary>
        /// สร้าง GameTable เริ่มต้นจากค่าที่กำหนด
        /// </summary>
        /// <param name="tableCount">จำนวนโต๊ะที่เล่นได้พร้อมกัน</param>
        /// <param name="gameDuration">ระยะเวลาในการเล่นของแต่ละโต๊ะ</param>
        /// <param name="gameInterval">ระยะห่างระหว่างการเริ่มเกมของโต๊ะ</param>
        /// <returns>โต๊ะที่สร้างจากเงื่อนไขที่กำหนด</returns>
        public IEnumerable<GameTable> GenerateTableConfiguration(int tableCount, int gameDuration, int gameInterval)
        {
            List<GameTable> lst = new List<GameTable>();

            for (int i = 0; i < tableCount; i++) {
                lst.Add(new GameTable {
                    TableID = i + 1,
                    GameDuration = gameDuration,
                    GameInterval = gameInterval,
                });
            }

            return lst.ToArray();
        }

        /// <summary>
        /// บันทึกการตั้งค่าของโต๊ะ
        /// </summary>
        /// <param name="name">ชื่อ setting</param>
        /// <param name="tables">การตั้งค่าของโต๊ะต่าง ๆ</param>
        void SaveTableConfiguration(string name, IEnumerable<GameTable> tables)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// สร้าง GameRound จาก setting โดยการระบุชื่อ ให้จำนวนของ GameRound ที่เล่นได้เต็มจำนวนโต๊ะและเพิ่มไปเท่าที่กำหนด
        /// </summary>
        /// <param name="name">ชื่อ setting</param>
        /// <param name="bufferRoundsCount">จำนวนโต๊ะที่สร้างให้เกินจากที่บันทึกไว้</param>
        void CreateGameRounds(string name, int bufferRoundsCount)
        {
            throw new NotImplementedException();
        }
    }
}
