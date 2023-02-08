using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    int defaultTime = 60;
    int leftTime = 0;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftTime <= 0)
        {
            timeOver();
            return;
        }
    }

    private void OnEnable()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 100;
        leftTime = defaultTime;
        StartCoroutine(updateSeconds());
    }

    void timeOver() {

    }

    IEnumerator updateSeconds()
    {
        while (true)
        {
            leftTime -= 1;
            slider.value = (1f / defaultTime) * leftTime;
            yield return new WaitForSeconds(1f);
            Debug.Log("EXECUTED");
        }
    }
}
