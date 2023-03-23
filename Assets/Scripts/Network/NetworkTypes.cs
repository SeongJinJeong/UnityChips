using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkDataStuct
{
    public class DataLogin
    {
        public string name;
    }

    public class DataLoginSucceed
    {
        public string name;
        public int id;
    }

    public class DataEnterLobby
    {

    }

    public class DataEnterLobbySucceed
    {

    }

    public interface DataRoomData
    {
        string roomid { get; set; }
        string roomName { get; set; }
        int playerCount { get; set; }

    }
    public class DataGetLobbyRooms
    {
        public List<DataRoomData> rooms;
    }
}
