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
    }

    #region [ Reciever Callbacks ]
    private void onLoginSucceed(SocketIOResponse data)
    {
        Util.logData<DataLoginSucceed>(data);
        // go to lobby scene
    }

    private void onEnterLobbySucceed(SocketIOResponse data)
    {
        Util.logData<DataEnterLobbySucceed>(data);
        // initialize Lobby
    }

    private void onGetLobbyRooms(SocketIOResponse data)
    {
        Util.logData<DataGetLobbyRooms>(data);
        // Draw Rooms in the Lobby Scroll View
    }
    #endregion

    #region
    public void emitEnterLobby()
    {
        DataEnterLobby data = new DataEnterLobby();
        this.netHandler.emit("onEnterLobby", Util.toJson<DataEnterLobby>(data));
    }
    #endregion

    public void emitMsg (string ev, object value)
    {
        this.netHandler.emit(ev,value);
    }

    public void onMsg (object data)
    {
        Debug.Log(data);
    }
}
