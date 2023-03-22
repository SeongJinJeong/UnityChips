using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using NetworkDataStuct;

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
    }

    public void emitMsg (string ev, object value)
    {
        this.netHandler.emit(ev,value);
    }

    public void onMsg (object data)
    {
        Debug.Log(data);
    }
}
