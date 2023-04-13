using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkDataStuct
{
    #region [ Emitter ]
    [Serializable]
    public class EmitDataLogin
    {
        public string name;
    }

    [Serializable]
    public class EmitDataEnterLobby
    {

    }

    [Serializable]
    public class EmitDataGetLobbyRooms
    {

    }

    [Serializable]
    public class EmitDataEnterRoom
    {
        public string roomid;
    }


    [Serializable]
    public class EmitDataGetRoomData
    {
        public string roomid;
    }

    [Serializable]
    public class EmitDataChatRoom
    {
        public string msg;
        public string roomid;
    }

    [Serializable]
    public class EmitDataLeaveGameRoom
    {
        public string roomid;
    }

    // IN GAME
    [Serializable]
    public class EmitDataGameStart
    {
        public string roomid;
        public int budgetPerPlayer;
        public int playerCount;
        public int timer;
        public int entryFee;
    }

    [Serializable]
    public class EmitDataPlayerReady
    {
        public string roomid;
    }

    [Serializable]
    public class EmitDataPlayerBet
    {
        public string roomid;
        public string betType;
    }

    #endregion
    #region [ Reciver ]
    [Serializable]
    public class DataOnLoginSucceed
    {
        public int code;
        public string name;
        public int id;
    }

   [Serializable]
    public class DataOnEnterLobbySucceed
    {
        public int code;
    }

    [Serializable]
    public class DataRoomData
    {
        public string roomid;
        public int playerCount;

    }

    [Serializable]
    public class DataRoomPlayers
    {
        public string name;
    }

    [Serializable]
    public class DataOnGetLobbyRooms
    {
        public int code;
        public List<DataRoomData> rooms;
    }

    [Serializable]
    public class DataOnGameRoom
    {
        public int code;
        public DataRoomData roomData;
        public DataRoomPlayers[] roomPlayers;
    }

    [Serializable]
    public class DataOnLeaveGameRoom
    {
        public int code;
    }
    #endregion

    #region
    [Serializable]
    public class DataPlayer
    {
        public string name;
        public string id;
        public string roomid;
    }
    #endregion
}
