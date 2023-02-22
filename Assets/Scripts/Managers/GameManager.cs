using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager getInstance()
    {
        if(instance == null)
        {
            return null;
        }

        return instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(null == instance)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
