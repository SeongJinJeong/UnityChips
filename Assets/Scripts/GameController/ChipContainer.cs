using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipContainer : MonoBehaviour
{
    List<GameObject> Chips = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ChipContainer generateChips(int count)
    {
        for(int i=0; i < count; i++)
        {
            string chipName = gameObject.name.Substring(0, gameObject.name.Length -"Container".Length);
            string chipPath= "Prefabs/Game/" + chipName;
            GameObject chip = Resources.Load(chipPath) as GameObject;
            GameObject instantiatedChip = Instantiate(chip);
            Chips.Add(instantiatedChip);
            instantiatedChip.name = chipName + i;
            instantiatedChip.transform.SetParent(transform);
            instantiatedChip.SetActive(false);
        }

        return this;
    }

    public void throwChips(int count)
    {
        if(this.Chips.Count < count)
        {
            this.generateChips(count - this.Chips.Count);
        }
        for(var i=0; i<count; i++)
        {
            this.Chips[i].SetActive(true);
            this.Chips[i].GetComponent<ChipController>().throwChip();
        }
    }
}
