using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using NetworkDataStuct;
using SocketIOClient;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        } else
        {
            Destroy(this.gameObject);
        }
    }
    public static NetworkManager getInstance()
    {
        if (instance == null)
            return null;

        return instance;
    }

    private object currentManager = null;
    private NetHandler netHandler = null;
    // Start is called before the first frame update
    private async void Start()
    {
        this.netHandler = new NetHandler();
        await this.netHandler.connect();
        this.initReciver();

        //SceneManager.sceneLoaded -= this.onSceneLoaded;
        //SceneManager.sceneLoaded += this.onSceneLoaded;
    }

    private void OnDestroy()
    {
        this.netHandler.disconnect();
    }

    private void initReciver()
    {
        this.netHandler.AddListener("loginSucceed", this.onLoginSucceed);
        this.netHandler.AddListener("onEnterLobbySucceed", this.onEnterLobbySucceed);
        this.netHandler.AddListener("onGetLobbyRooms", this.onGetLobbyRooms);
        this.netHandler.AddListener("onGameRoomData", this.onGameRoomData);
        this.netHandler.AddListener("onLeaveGameRoom", this.onLeaveGameRoom);
    }

    #region [ Reciever ]
    private void onLoginSucceed(SocketIOResponse data)
    {
        this.executeListenerOnMainThread(() =>
        {
            Debug.Log("LoginSucceed");
            Util.logData<DataOnLoginSucceed>(data);
            MainManager.getInstance().changeSceneToLobby();

            DataPlayer playerData = JsonUtility.FromJson<DataPlayer>(data.GetValue<string>(0));
            PlayerDataContainer.getInstance().setPlayerData(playerData);
        });
    }

    private void onEnterLobbySucceed(SocketIOResponse data)
    {
        this.executeListenerOnMainThread(() =>
        {
            Util.logData<DataOnEnterLobbySucceed>(data);
            GameObject.Find("LobbyManager").GetComponent<LobbyManager>().onEnterLobbySucceed();
        });
    }

    private void onGetLobbyRooms(SocketIOResponse data)
    {
        Util.logData<DataOnGetLobbyRooms>(data);
    }

    public void onGameRoomData(SocketIOResponse data)
    {
        this.executeListenerOnMainThread(() =>
        {
            Util.logData<DataOnGameRoom>(data);
            DataOnGameRoom parsedData = JsonUtility.FromJson<DataOnGameRoom>(data.GetValue<string>(0));

            // Draw Rooms in the Lobby Scroll View
            DataPlayer playerData = PlayerDataContainer.getInstance().getPlayerData();
            Debug.Log(playerData.id);
            playerData.roomid = parsedData.roomData.roomid;
            PlayerDataContainer.getInstance().setPlayerData(playerData);
            PlayerDataContainer.getInstance().setRoomData(parsedData.roomData);
            Debug.Log(PlayerDataContainer.getInstance().getRoomData().playerCount);

            GameObject.Find("LobbyManager").GetComponent<LobbyManager>().onEnterRoomSucceed();
        });
    }

    public void onLeaveGameRoom(SocketIOResponse data)
    {
        Util.logData<DataOnLeaveGameRoom>(data);
    }
    #endregion

    #region [ Emitter ]
    public void emitLogin(string name)
    {
        EmitDataLogin data = new EmitDataLogin();
        data.name = name;
        this.netHandler.emit("onLogin", Util.toJson(data));
    }
    public void emitEnterLobby()
    {
        EmitDataEnterLobby data = new EmitDataEnterLobby();
        this.netHandler.emit("onEnterLobby", Util.toJson(data));
    }

    public void emitGetLobbyRooms()
    {
        EmitDataGetLobbyRooms data = new EmitDataGetLobbyRooms();
        this.netHandler.emit("onGetLobbyRooms", Util.toJson(data));
    }

    public void emitEnterRoom(string roomid)
    {
        EmitDataEnterRoom data = new EmitDataEnterRoom();
        data.roomid = roomid;
        this.netHandler.emit("onEnterRoom", Util.toJson(data));
    }

    public void emitGetRoomData(string roomid)
    {
        EmitDataGetRoomData data = new EmitDataGetRoomData();
        data.roomid = roomid;
        this.netHandler.emit("onGetRoomData", Util.toJson(data));
    }

    public void emitChatRoom(string msg, string roomid)
    {
        EmitDataChatRoom data = new EmitDataChatRoom();
        data.msg = msg;
        data.roomid = roomid;
        this.netHandler.emit("onChatRoom", Util.toJson(data));
    }

    public void emitLeaveGameRoom(string roomid)
    {
        EmitDataLeaveGameRoom data = new EmitDataLeaveGameRoom();
        data.roomid = roomid;
        this.netHandler.emit("onLeaveGameRoom", Util.toJson(data));
    }

    public void emitGameStart(string roomid, int budgetPerPlayer, int playerCount, int timer, int entryFee)
    {
        EmitDataGameStart data = new EmitDataGameStart();
        data.roomid = roomid;
        data.budgetPerPlayer = budgetPerPlayer;
        data.playerCount = playerCount;
        data.timer = timer;
        data.entryFee = entryFee;
        this.netHandler.emit("onGameStart", Util.toJson(data));
    }

    public void emitPlayerReady(string roomid)
    {
        EmitDataPlayerReady data = new EmitDataPlayerReady();
        data.roomid = roomid;
        this.netHandler.emit("onPlayerReady", Util.toJson(data));
    }

    public void emitPlayerBet(string roomid, string betType)
    {
        EmitDataPlayerBet data = new EmitDataPlayerBet();
        data.roomid = roomid;
        data.betType = betType;
        this.netHandler.emit("onPlayerBet", Util.toJson(data));
    }
    #endregion

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Lobby")
        {
            this.currentManager = GameObject.Find("LobbyManager").GetComponent<LobbyManager>();
        }
    }

    private void executeListenerOnMainThread(Action cb)
    {
        Debug.Log(Thread.CurrentThread == MainManager.mainThread);
        UnityMainThreadDispatcher.Instance().Enqueue(cb);
    }
}
