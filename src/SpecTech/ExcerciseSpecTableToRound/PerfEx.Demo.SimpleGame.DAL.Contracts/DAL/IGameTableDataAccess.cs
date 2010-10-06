using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;
using PerfEx.Demo.SimpleGame.Commands;

namespace PerfEx.Demo.SimpleGame.DAL
{
    public interface IGameTableDataAccess :
        IListGameTableConfiguration,
        IListActiveRounds,

        ICreateGameTableConfiguration,
        ICreateGameRound,
        IListGamePlayInformation
    { }

    /// <summary>
    /// list GameTable ใน configuration
    /// </summary>
    public interface IListGameTableConfiguration
    {
        IEnumerable<GameTable> List(ListGameTableConfigurationsCommand cmd);
    }

    /// <summary>
    /// list GameRound ที่สามารถเล่นได้ ณ. เวลา ที่กำหนด
    /// </summary>
    public interface IListActiveRounds
    {
        IEnumerable<GameRound> List(ListActiveGameRoundsCommand cmd);
    }

    /// <summary>
    /// บันทึกการตั้งค่าเกม
    /// </summary>
    public interface ICreateGameTableConfiguration
    {
        void Create(CreateGameTableConfigurationsCommand cmd);
    }

    /// <summary>
    /// บันทึก GameRound (สร้างใหม่)
    /// </summary>
    public interface ICreateGameRound
    {
        void Create(GameRound entity, CreateGameRoundCommand cmd);
    }

    /// <summary>
    /// List GamePlayInfomation that User is playing
    /// </summary>
    public interface IListGamePlayInformation {
        IEnumerable<GamePlayInfomation> List(ListGamePlayInformationCommand cmd);
    }
}
