using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipController : MonoBehaviour
{
    [SerializeField]
    float defaultRotateDegree = 1.0f;
    [SerializeField]
    float animationDuartion = 2.0f;
    float bigScale = 1.2f;
    float defaultScale = 0.7f;
    bool reachEnd = true;

    string from = null;

    GameObject owner = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reachEnd = this.checkEnd();

        if(reachEnd == false)
        {
            updateAnim();
        }
        else
        {
            onEndThrow();
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0f, -4.2f, 0f);
        transform.eulerAngles= new Vector3(0f, 0f, 0f);
        transform.localScale = new Vector3(bigScale, bigScale, 0f);
    }
    
    bool checkEnd()
    {
        if (transform.position.x == 0 && transform.position.y == 0)
            return true;

        if (transform.localScale.x <= defaultScale)
            return true;

        return false;
    }
    void onEndThrow()
    {

    }
    //endregion

    public void throwChip(string path)
    {
        from = path.ToLower();

        //todo 나중에 플레이어 가져오는거 구현해야 함.
        owner = GameObject.Find("MyPlayer");

        reachEnd = false;
    }

    void updateAnim()
    {
        changeRotate();
        changeScale();
        changePos();
    }

    void changeRotate()
    {
        Vector3 currRotate = transform.eulerAngles;
        if (currRotate.z >= 180)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        transform.eulerAngles = new Vector3(currRotate.x, currRotate.y, currRotate.z + defaultRotateDegree);
    }
    void changeScale()
    {
        float scaleVal = (bigScale - defaultScale) / animationDuartion * Time.deltaTime;
        Vector3 currScale = transform.localScale;
        transform.localScale = new Vector3(currScale.x - scaleVal, currScale.y - scaleVal);
    }

    void changePos()
    {
        switch (from)
        {
            case "left":
                moveFromLeft();
                break;
            case "right":
                moveFromRight();
                break;
            case "up":
                moveFromUp();
                break;
            case "down":
                moveFromDown();
                break;
            default:
                Debug.LogError("Direction is not defined");
                break;
        }
    }

    void moveFromLeft()
    {
        float moveVal = Mathf.Abs(owner.transform.position.x) / animationDuartion * Time.deltaTime;
        Vector3 currPos = transform.position;
        transform.position = new Vector3(currPos.x + moveVal, 0f, 0f);
    }
    void moveFromRight()
    {
        float moveVal = -owner.transform.position.x / animationDuartion * Time.deltaTime;
        Vector3 currPos = transform.position;
        transform.position = new Vector3(currPos.x + moveVal, 0f, 0f);
    }
    void moveFromUp()
    {
        float moveVal = -owner.transform.position.y / animationDuartion * Time.deltaTime;
        Vector3 currPos = transform.position;
        transform.position = new Vector3(0f, currPos.y + moveVal, 0f);
    }
    void moveFromDown()
    {
        float moveVal = Mathf.Abs(owner.transform.position.y) / animationDuartion * Time.deltaTime;
        Vector3 currPos = transform.position;
        transform.position = new Vector3(0f, currPos.y + moveVal, 0f);
    }
}
