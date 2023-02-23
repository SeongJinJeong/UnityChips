using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHEEP_TYPE{
    static class Cheep_Type
    {
        public static Dictionary<string,string> CHIP = new Dictionary<string,string>()
        {
            {"Green", "Green" },
            {"Blue", "Blue" },
            {"Red", "Red" },
            {"White", "White" },
            {"Black", "Black" }
        };
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

    public void throwChipByName(int count, string chipType) {
        ChipContainer container = null;
        for(var i=0; i<this.ChipContainers.Count; i++)
        {
            string containerName = "Chip" + chipType + "Container";
            if (this.ChipContainers[i].gameObject.name == containerName)
            {
                container = this.ChipContainers[i];
                break;
            }
        }

        if(container != null)
            container.throwChips(count);
    }

}
