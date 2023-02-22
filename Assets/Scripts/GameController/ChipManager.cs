using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour
{
    private List<ChipContainer> ChipContainers = new List<ChipContainer>();
    // Start is called before the first frame update
    void Start()
    {
        this.initChips();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initChips() {
        for(int i=0; i<transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ChipContainers.Add(child.GetComponent<ChipContainer>().generateChips(10));
        }
    }
}
