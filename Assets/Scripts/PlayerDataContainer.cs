﻿using System;
using NetworkDataStuct;
using UnityEngine;

public class PlayerDataContainer
{
    private static PlayerDataContainer instance = null;
    public static PlayerDataContainer getInstance()
    {
        if (instance == null)
            instance = new PlayerDataContainer();

        return instance;
    }

    private DataPlayer playerInfo = null;
    private DataRoomData roomInfo = null;
    public void setPlayerData(DataPlayer data)
    {
        if (data.roomid == null)
            data.roomid = data.id;
        this.playerInfo = data;
        Debug.Log(JsonUtility.ToJson(data));
    }
    public DataPlayer getPlayerData()
    {
        return this.playerInfo;
    }

    public void setRoomData(DataRoomData data)
    {
        this.roomInfo = data;
    }

    public DataRoomData getRoomData()
    {
        return this.roomInfo;
    }
}
