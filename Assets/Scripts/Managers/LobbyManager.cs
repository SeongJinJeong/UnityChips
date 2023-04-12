using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NetworkDataStuct;
using System.Threading;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    GameObject NameField;

    // Start is called before the first frame update
    void Start()
    {
        this._processEnterLobby();
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
        this._onEnterLobbySucceed(); // <-- This is not working.
    }
    public void _onEnterLobbySucceed()
    {
        Destroy(GameObject.FindGameObjectWithTag("GrayLayer"));
        Destroy(GameObject.FindGameObjectWithTag("Loading"));

        DataPlayer playerData = PlayerDataContainer.getInstance().getPlayerData();
        NameField.GetComponent<TMP_Text>().text = playerData.name;
        NetworkManager.getInstance().emitEnterRoom(playerData.id);
    }

    public void onEnterRoomSucceed()
    {
        
    }
}
