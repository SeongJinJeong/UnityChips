using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    GameObject NameField;

    private bool _lobbyEnterSucceed = false;
    // Start is called before the first frame update
    void Start()
    {
        this._processEnterLobby();
    }

    private void Update()
    {
        if(this._lobbyEnterSucceed == true)
        {
            this._onEnterLobbySucceed();
            this._lobbyEnterSucceed = false;
        }
    }

    private void _processEnterLobby()
    {
        GameObject grayLayer = Resources.Load<GameObject>("Prefabs/Common/GrayLayer");
        GameObject grayLayerObject = Instantiate<GameObject>(grayLayer);

        GameObject loading = Resources.Load<GameObject>("Prefabs/Common/Loading");
        GameObject loadingObject = Instantiate<GameObject>(loading);

        NetworkManager.getInstance().emitEnterLobby();
    }

    public void onEnterLobbySucceed()
    {
        Debug.Log("Enter Lobby Succeed!");
        this._lobbyEnterSucceed = true;
        this._onEnterLobbySucceed(); // <-- This is not working.
    }
    public void _onEnterLobbySucceed()
    {
        Destroy(GameObject.FindGameObjectWithTag("GrayLayer"));
        Destroy(GameObject.FindGameObjectWithTag("Loading"));
        string userName = PlayerDataContainer.getInstance().getPlayerData().name;
        NameField.GetComponent<TMP_Text>().text = userName;
    }
}
