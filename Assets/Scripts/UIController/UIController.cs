using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private ChipManager chipController;
    // Start is called before the first frame update
    void Start()
    {
        chipController = GameManager.getInstance().getChipManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setAllButtonVisible(bool visible)
    {
        for (var i = 0; i < this.transform.childCount; i++)
        {
            string childName = this.transform.GetChild(i).name;
            if (childName == "BettingBtns" || childName == "Slider")
            {
                this.transform.GetChild(i).gameObject.SetActive(visible);
            }
        }
    }

    public void setSliderVisible(bool visible)
    {
        for (var i = 0; i < this.transform.childCount; i++)
        {
            string childName = this.transform.GetChild(i).name;
            if (childName == "Slider")
            {
                this.transform.GetChild(i).gameObject.SetActive(visible);
            }
        }
    }

    void onClickButton()
    {
        this.setAllButtonVisible(false);
        this.setSliderVisible(false);
    }

    public void onClickCall()
    {
        this.onClickButton();

        string chipType = this.getRandomChip();
        this.chipController.throwChipByName(5, chipType);
    }

    public void onClickHalf()
    {
        this.onClickButton();
        string chipType = this.getRandomChip();
        this.chipController.throwChipByName(10, chipType);
    }

    public void onClickCheck()
    {
        this.onClickButton();
    }

    public void onClickDie()
    {
        this.onClickButton();
    }

    private string getRandomChip()
    {
        int randomChip = Random.Range(0, CHEEP_TYPE.Cheep_Type.CHIP.Count);
        List<string> Chips = new List<string>();
        foreach (KeyValuePair<string, string> item in CHEEP_TYPE.Cheep_Type.CHIP)
        {
            Chips.Add(item.Value);
        }

        return Chips[randomChip];
    }
}
