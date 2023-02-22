using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipController : MonoBehaviour
{
    [SerializeField]
    float defaultRotateDegree = 1.0f;
    [SerializeField]
    float animationDuartion = 2.0f;
    [SerializeField]
    float bigScale = 1.2f;
    [SerializeField]
    float defaultScale = 0.7f;

    Vector3 MaxReachPos = new Vector3(3, 2);
    Vector3 MinReachPos = new Vector3(-3, -1);

    string from = null;
    bool reachEnd = true;
    GameObject owner = null;
    Vector3 distance = Vector3.zero;
    float tick = 0f;
    float currDt = 0f;

    private Vector3 reachPos = Vector3.zero;

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
        transform.position = new Vector3(0f, -10f, 0f);
        transform.eulerAngles= new Vector3(0f, 0f, 0f);
        transform.localScale = new Vector3(bigScale, bigScale, 0f);
    }
    
    bool checkEnd()
    {
        if (transform.position.x == reachPos.x && transform.position.y == 0)
            return true;

        if (transform.localScale.x <= defaultScale)
            return true;

        return false;
    }
    void onEndThrow()
    {
        this.tick = 0f;
        this.currDt = 0f;
        this.reachPos = Vector3.zero;
    }
    //endregion

    // ���߿� Ĩ ���� �� �÷��̾� ��ġ �˷�����
    public void throwChip(string path)
    {
        from = path.ToLower();

        //todo ���߿� �÷��̾� �������°� �����ؾ� ��.
        owner = GameObject.Find("MyPlayer");
        transform.position = owner.transform.position;

        this.reachPos = new Vector3(Random.Range(this.MinReachPos.x, this.MaxReachPos.x), Random.Range(this.MinReachPos.y, this.MaxReachPos.y));
        this.distance = new Vector3(Mathf.Abs(reachPos.x - owner.transform.position.x), Mathf.Abs(reachPos.y - owner.transform.position.y));

        reachEnd = false;
    }

    void updateAnim()
    {
        this.currDt = Time.deltaTime;
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
        float scaleVal = (bigScale - defaultScale) / animationDuartion * this.currDt;
        Vector3 currScale = transform.localScale;
        transform.localScale = new Vector3(currScale.x - scaleVal, currScale.y - scaleVal);
    }
    
    void changePos()
    {
        //switch (from)
        //{
        //    case "left":
        //        moveFromLeft();
        //        break;
        //    case "right":
        //        moveFromRight();
        //        break;
        //    case "up":
        //        moveFromUp();
        //        break;
        //    case "down":
        //        moveFromDown();
        //        break;
        //    default:
        //        Debug.LogError("Direction is not defined");
        //        break;
        //}

        this.moveChip();
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
        float dt = Time.deltaTime;
        float moveValX = Mathf.Abs(distance.x / (animationDuartion - this.tick) * dt);
        float moveValY = Mathf.Abs(distance.y / (animationDuartion - this.tick) * dt);
        this.tick += dt;

        Vector3 currPos = transform.position;

        if (owner.transform.position.x > 0)
            moveValX = -moveValX;
        if (owner.transform.position.y > 0)
            moveValY = -moveValY;

        transform.position = new Vector3(currPos.x + moveValX, currPos.y + moveValY, 0f);
    }
    void moveFromDown()
    {
        float moveValX = Mathf.Abs(owner.transform.position.x) / animationDuartion * Time.deltaTime;
        float moveValY = Mathf.Abs(owner.transform.position.y) / animationDuartion * Time.deltaTime;

        Vector3 currPos = transform.position;

        if (currPos.x > 0)
            moveValX = -moveValX;
        if (currPos.y > 0)
            moveValY = -moveValY;

        transform.position = new Vector3(currPos.x + moveValX, currPos.y + moveValY, 0f);
    }

    void moveChip()
    {
        float moveValX = Mathf.Abs(distance.x / (animationDuartion - this.tick) * this.currDt);
        float moveValY = Mathf.Abs(distance.y / (animationDuartion - this.tick) * this.currDt);
        this.tick += this.currDt;

        if (owner.transform.position.x > 0)
            moveValX = -moveValX;
        if (owner.transform.position.y > 0)
            moveValY = -moveValY;

        Vector3 currPos = transform.position;
        transform.position = new Vector3(currPos.x + moveValX, currPos.y + moveValY, 0f);
    }
}
