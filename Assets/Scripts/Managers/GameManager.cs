using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ChipManager chipController;
    private PlayerController playerController;
    private UIController uiController;


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

    private void Start()
    {
        this.playerController = GameObject.Find("PlayerContainer").GetComponent<PlayerController>();
        this.chipController = GameObject.Find("ChipContainer").GetComponent<ChipManager>();
        this.uiController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    public ChipManager getChipManager()
    {
        return this.chipController;
    }

    public void timeOver()
    {
        this.uiController.setAllButtonVisible(false);
        this.uiController.setSliderVisible(false);
    }
}
