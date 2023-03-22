using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryEventController : MonoBehaviour
{
    [SerializeField]
    NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendMessage()
    {
        this.networkManager.emitMsg("seongjin");
    }
}
