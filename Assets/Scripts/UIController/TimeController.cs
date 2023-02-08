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

    IEnumerator currCoroutine;
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
        currCoroutine = updateSeconds(defaultTime);         // coroutine 에 파라미터 넘길 때에는 이렇게 해야됨.
        StartCoroutine(currCoroutine);
    }

    void timeOver() {
        StopCoroutine(currCoroutine);
    }

    IEnumerator updateSeconds(float second)
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
