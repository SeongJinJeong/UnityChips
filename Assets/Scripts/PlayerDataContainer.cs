using System;
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
    public void setPlayerData(DataPlayer data)
    {
        this.playerInfo = data;
        Debug.Log(JsonUtility.ToJson(data));
    }
    public DataPlayer getPlayerData()
    {
        return this.playerInfo;
    }
}
