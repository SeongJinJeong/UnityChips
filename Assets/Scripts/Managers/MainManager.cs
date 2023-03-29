using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
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
        }
    }

    private void OnEnable()
    {
        //StartCoroutine(loadLobbyScene());
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
