using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipController : MonoBehaviour
{
    [SerializeField]
    float defaultRotateDegree = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Vector3 currRotate = transform.eulerAngles;
            if (currRotate.z >= 180)
                transform.eulerAngles = new Vector3(0f, 0f, 0f);

            transform.eulerAngles = new Vector3(currRotate.x, currRotate.y, currRotate.z + defaultRotateDegree);
        }
    }

    private void OnEnable()
    {
        transform.eulerAngles= new Vector3(0f, 0f, 0f);
    }
    
}
