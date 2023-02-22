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

    private void onClickButton()
    {
        for(var i=0; i<this.uiController.transform.childCount; i++)
        {
            string childName = this.uiController.transform.GetChild(i).name;
            if (childName == "BettingBtns" || childName == "Slider")
            {
                this.uiController.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void onClickCall()
    {
        this.onClickButton();

        // todo 버튼 클릭 구현하자
        int randomChip = CHEEP_TYPE.Cheep_Type.
        this.chipController.throwChipByName(5, CHEEP_TYPE.Cheep_Type.White);
    }
}
