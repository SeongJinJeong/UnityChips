using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class MainManager : MonoBehaviour
{
    static public Thread mainThread;
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


    // Main
    private GameObject grayLayer = null;
    private void Start()
    {
        mainThread = Thread.CurrentThread;
    }
    private void OnEnable()
    {
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
        this.spawnGrayLayer();
        StartCoroutine(loadLobbyScene());
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
    public void spawnGrayLayer()
    {
        GameObject gray = Resources.Load<GameObject>("Prefabs/Common/GrayLoading");
        this.grayLayer = Instantiate<GameObject>(gray);
    }
    public void removeGrayLayer()
    {
        Destroy(this.grayLayer);
        this.grayLayer = null;
    }
    
}
