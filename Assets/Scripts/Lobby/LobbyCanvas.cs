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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addList(string playerName)
    {
        int index = listContent.transform.childCount % 2 + 1;
        GameObject list = Resources.Load<GameObject>("Prefabs/Lobby/ScrollList" + index);
        GameObject instantiatedList = Instantiate(list);
        instantiatedList.transform.SetParent(listContent.transform);
        instantiatedList.transform.localScale = new Vector3(1,1,1);
        instantiatedList.GetComponent<TMP_Text>().text = playerName;
    }

    
}
