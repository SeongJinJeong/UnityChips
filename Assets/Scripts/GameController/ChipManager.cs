using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHEEP_TYPE{
    static class Cheep_Type
    {
        public static Dictionary<string,int> CHIP = new Dictionary<string,int>()
        {
            {"Green", 0 },
            {"Blue", 1 },
            {"Red", 1 },
            {"White", 1 },
            {"Black", 1 }
        };
        public const int Green = 0;
        public const int Blue = 1;
        public const int Red = 2;
        public const int White = 3;
        public const int Black = 4;
    }
}

public class ChipManager : MonoBehaviour
{
    private List<ChipContainer> ChipContainers = new List<ChipContainer>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
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

    public void throwChipByName(int count, int chipType) {
        ChipContainer container = null;
        for(var i=0; i<this.ChipContainers.Count; i++)
        {
            if (this.ChipContainers[i].gameObject.name == "ChipGreenContainer")
            {
                container = this.ChipContainers[i];
                break;
            }
        }

        if(container != null)
            container.throwChips(count);
    }

}
