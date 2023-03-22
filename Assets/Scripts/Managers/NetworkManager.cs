using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;

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

    public void emitMsg (string value)
    {
        Data data = new Data();
        data.name = value;
        this.netHandler.emit(data);
    }
}

public class Data
{
    public string name;
}
