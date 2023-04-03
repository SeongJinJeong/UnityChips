using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    [SerializeField]
    float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(startRotate());
    }

    private IEnumerator startRotate()
    {
        float currRotate = 0f;
        while (true)
        {
            currRotate += RotateSpeed ;
            transform.rotation = Quaternion.Euler(0, 0, currRotate);
            if (currRotate > 360)
                currRotate = 0f;
            yield return new WaitForFixedUpdate();
        }
    }
}
