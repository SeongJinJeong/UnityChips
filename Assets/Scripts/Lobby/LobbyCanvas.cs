using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    GameObject listContent;
    // Start is called before the first frame update
    void Start()
    {
        listContent = GameObject.FindGameObjectWithTag("ListContent");
        for(var i=0; i<5; i++)
        {
            this.addList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void addList()
    {
        int index = listContent.transform.childCount / 2 + 1;
        GameObject list = Resources.Load<GameObject>("Prefabs/Lobby/ScrollList" + index);
        GameObject instantiatedList = Instantiate(list);
        instantiatedList.transform.parent = listContent.transform;
    }
}
