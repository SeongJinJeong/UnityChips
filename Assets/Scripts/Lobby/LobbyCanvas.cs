using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyCanvas : MonoBehaviour
{
    GameObject listContent;
    Vector3 DefaultScale = new Vector3(532, 102, 1);
    Vector3 DefaultPosition = new Vector3(220, 0, 0);
    int startYPos = -43;
    int defaultGap = -84;
    // Start is called before the first frame update
    void Start()
    {
        listContent = GameObject.FindGameObjectWithTag("ListContent");
        for(var i=0; i<20; i++)
        {
            this._addList();
        }

        this._processEnterLobby();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _addList()
    {
        int index = listContent.transform.childCount % 2 + 1;
        GameObject list = Resources.Load<GameObject>("Prefabs/Lobby/ScrollList" + index);
        GameObject instantiatedList = Instantiate(list);
        instantiatedList.transform.SetParent(listContent.transform);
        instantiatedList.transform.localScale = new Vector3(1,1,1);
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
        this._onEnterLobbySucceed(); 
    }
    private void _onEnterLobbySucceed()
    {
        GameObject.Find("TextUserName").GetComponent<TMP_Text>().text = PlayerDataContainer.getInstance().getPlayerData().name;
    }
    public void test()
    {
        Debug.Log("test");
    }
}
