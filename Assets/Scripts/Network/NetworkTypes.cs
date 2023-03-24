using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkDataStuct
{
    #region [ Emitter ]
    public class EmitDataLogin
    {
        public string name;
    }

    public class EmitDataEnterLobby
    {

    }

    public class EmitDataGetLobbyRooms
    {

    }

    public class EmitDataEnterRoom
    {
        public string roomid;
    }

    public class EmitDataChatRoom
    {
        public string msg;
        public string roomid;
    }

    public class EmitDataLeaveGameRoom
    {
        public string roomid;
    }

    // IN GAME
    public class EmitDataGameStart
    {
        public string roomid;
        public int budgetPerPlayer;
        public int playerCount;
        public int timer;
        public int entryFee;
    }

    public class EmitDataPlayerReady
    {
        public string roomid;
    }

    public class EmitDataPlayerBet
    {
        public string roomid;
        public string betType;
    }

    #endregion
    #region [ Reciver ]
    public class DataOnLoginSucceed
    {
        public int code;
        public string name;
        public int id;
    }


    public class DataOnEnterLobbySucceed
    {
        public int code;
    }

    public interface DataRoomData
    {
        public string roomid { get; set; }
        public string roomName { get; set; }
        public int playerCount { get; set; }

    }
    public interface DataRoomPlayers
    {
        string name { get; set; }
    }

    public class DataOnGetLobbyRooms
    {
        public int code;
        public List<DataRoomData> rooms;
    }

    public class DataOnGameRoom
    {
        public int code;
        public DataRoomData roomData;
        public List<DataRoomPlayers> roomPlayers;
    }

    public class DataOnLeaveGameRoom
    {
        public int code;
    }
    #endregion
}
