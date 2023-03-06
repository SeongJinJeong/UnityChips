using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayLayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int Opacity = 0;
    void Start()
    {
        this.transform.GetComponent<SpriteRenderer>().material.SetColor("_TintColor", new Color(0,0,0,this.Opacity / 255));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
