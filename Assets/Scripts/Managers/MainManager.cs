using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static string currScene = "";

    static private MainManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static MainManager getInstance()
    {
        if (instance == null)
            return null;

        return instance;
    }

    private bool isLoadLobby = false;
    private void Update()
    {
        if(this.isLoadLobby == true)
        {
            StartCoroutine(loadLobbyScene());
            this.isLoadLobby = false;
            currScene = "Lobby";
        }
    }

    private void OnEnable()
    {
        //StartCoroutine(loadLobbyScene());
        this.initScreenResolution();
    }

    private void initScreenResolution()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Debug.Log("SCREEN WIDTH :"+Screen.width+"SCREEN HEIGHT :" + Screen.height);
        int defaultSize = (int)Mathf.Floor(Screen.height / 9);
        Screen.SetResolution(defaultSize * 16, defaultSize * 9,true);
    }

    public void changeSceneToLobby()
    {
        this.isLoadLobby = true;
    }

    private IEnumerator loadLobbyScene()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Single);
        while (!load.isDone)
        {
            Debug.Log(Mathf.Floor(load.progress * 100));
            yield return null;
        }
    }
}
