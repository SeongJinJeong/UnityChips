using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using NetworkDataStuct;
using SocketIOClient;

public class NetworkManager : MonoBehaviour
{
    private NetworkManager instance;
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
    public NetworkManager getInstance()
    {
        if (instance == null)
            return null;

        return instance;
    }

    private NetHandler netHandler = null;

    // Start is called before the first frame update
    void Start()
    {
        this.netHandler = new NetHandler();
        this.netHandler.connect();
        this.initReciver();
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
        Util.logData<DataOnLoginSucceed>(data);
        // go to lobby scene
    }

    private void onEnterLobbySucceed(SocketIOResponse data)
    {
        Util.logData<DataOnEnterLobbySucceed>(data);
        // initialize Lobby
    }

    private void onGetLobbyRooms(SocketIOResponse data)
    {
        Util.logData<DataOnGetLobbyRooms>(data);
        // Draw Rooms in the Lobby Scroll View
    }

    public void onGameRoomData(SocketIOResponse data)
    {
        Util.logData<DataOnGameRoom>(data);
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
    #endregion
}
