using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkleWall : MonoBehaviour
{
    float timeSpan;  // 경과 시간
    float WallReset; // 벽 초기화
    float A_WallTime = 1.0f;
    float B_WallTime = 1.0f;
    public GameObject Awall_0;
    public GameObject Awall_1;
    public GameObject Awall_2;
    public GameObject Awall_3;
    public GameObject Awall_4;
    public GameObject Awall_5;
    public GameObject Bwall_6;
    public GameObject Bwall_7;
    public GameObject Bwall_8;
    public GameObject Bwall_9;
    public GameObject Bwall_10;
    public GameObject Bwall_11;
    //--------------------------------------------
    public GameObject Awall_12;
    public GameObject Awall_13;
    public GameObject Awall_14;
    public GameObject Awall_15;
    public GameObject Awall_16;
    public GameObject Awall_17;
    public GameObject Awall_18;
    public GameObject Awall_19;

    public GameObject Bwall_12;
    public GameObject Bwall_13;
    public GameObject Bwall_14;
    public GameObject Bwall_15;
    public GameObject Bwall_16;
    public GameObject Bwall_17;
    public GameObject Bwall_18;
    public GameObject Bwall_19;
    //---------------------------------------------
    public GameObject Finish_wall0;
    public GameObject Finish_wall1;
    public GameObject Finish_wall2;
    public GameObject Finish_wall3;
    public GameObject Finish_wall4;
    public GameObject Finish_wall5;
    public GameObject Finish_wall6;
    public GameObject Finish_wall7;
    public GameObject Finish_wall8;
    public GameObject Finish_wall9;
  
    // Start is called before the first frame update
    void Start()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);

        Awall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);

        Finish_wall0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);   
    }

    void AWall()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_0.gameObject.tag = "Wall";
        Awall_1.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_1.gameObject.tag = "Wall";
        Awall_2.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_2.gameObject.tag = "Wall";
        Awall_3.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_3.gameObject.tag = "Wall";
        Awall_4.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_4.gameObject.tag = "Wall";
        Awall_5.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_5.gameObject.tag = "Wall";
        Bwall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_6.gameObject.tag = "Untagged";
        Bwall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_7.gameObject.tag = "Untagged";
        Bwall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_8.gameObject.tag = "Untagged";
        Bwall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_9.gameObject.tag = "Untagged";
        Bwall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_10.gameObject.tag = "Untagged";
        Bwall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_11.gameObject.tag = "Untagged";
        //--------------------------------------------------------------------------------------
        Awall_12.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_12.gameObject.tag = "Wall";
        Awall_13.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_13.gameObject.tag = "Wall";
        Awall_14.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_14.gameObject.tag = "Wall";
        Awall_15.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_15.gameObject.tag = "Wall";
        Awall_16.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_16.gameObject.tag = "Wall";
        Awall_17.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_17.gameObject.tag = "Wall";
        Awall_18.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_18.gameObject.tag = "Wall";
        Awall_19.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_19.gameObject.tag = "Wall";
        Bwall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_12.gameObject.tag = "Untagged";
        Bwall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_13.gameObject.tag = "Untagged";
        Bwall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_14.gameObject.tag = "Untagged";
        Bwall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_15.gameObject.tag = "Untagged";
        Bwall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_16.gameObject.tag = "Untagged";
        Bwall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_17.gameObject.tag = "Untagged";
        Bwall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_18.gameObject.tag = "Untagged";
        Bwall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_19.gameObject.tag = "Untagged";
        Finish_wall0.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall0.gameObject.tag = "Wall";
        Finish_wall1.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall1.gameObject.tag = "Wall";
        Finish_wall2.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall2.gameObject.tag = "Wall";
        Finish_wall3.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall3.gameObject.tag = "Wall";
        Finish_wall4.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall4.gameObject.tag = "Wall";
        Finish_wall5.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall5.gameObject.tag = "Wall";
        Finish_wall6.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall6.gameObject.tag = "Wall";
        Finish_wall7.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall7.gameObject.tag = "Wall";
        Finish_wall8.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall8.gameObject.tag = "Wall";
        Finish_wall9.GetComponent<SpriteRenderer>().material.color = Color.white;
        Finish_wall9.gameObject.tag = "Wall";
    }
    void BWall()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_0.gameObject.tag = "Untagged";
        Awall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_1.gameObject.tag = "Untagged";
        Awall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_2.gameObject.tag = "Untagged";
        Awall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_3.gameObject.tag = "Untagged";
        Awall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_4.gameObject.tag = "Untagged";
        Awall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_5.gameObject.tag = "Untagged";
        Bwall_6.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_6.gameObject.tag = "Wall";
        Bwall_7.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_7.gameObject.tag = "Wall";
        Bwall_8.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_8.gameObject.tag = "Wall";
        Bwall_9.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_9.gameObject.tag = "Wall";
        Bwall_10.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_10.gameObject.tag = "Wall";
        Bwall_11.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_11.gameObject.tag = "Wall";
        //--------------------------------------------------------------------------------------
        Awall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0); ;
        Awall_12.gameObject.tag = "Untagged";
        Awall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_13.gameObject.tag = "Untagged";
        Awall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_14.gameObject.tag = "Untagged";
        Awall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_15.gameObject.tag = "Untagged";
        Awall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_16.gameObject.tag = "Untagged";
        Awall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_17.gameObject.tag = "Untagged";
        Awall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_18.gameObject.tag = "Untagged";
        Awall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_19.gameObject.tag = "Untagged";
        Bwall_12.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_12.gameObject.tag = "Wall";
        Bwall_13.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_13.gameObject.tag = "Wall";
        Bwall_14.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_14.gameObject.tag = "Wall";
        Bwall_15.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_15.gameObject.tag = "Wall";
        Bwall_16.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_16.gameObject.tag = "Wall";
        Bwall_17.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_17.gameObject.tag = "Wall";
        Bwall_18.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_18.gameObject.tag = "Wall";
        Bwall_19.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_19.gameObject.tag = "Wall";
        Finish_wall0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall0.gameObject.tag = "Untagged";
        Finish_wall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall1.gameObject.tag = "Untagged";
        Finish_wall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall2.gameObject.tag = "Untagged";
        Finish_wall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall3.gameObject.tag = "Untagged";
        Finish_wall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall4.gameObject.tag = "Untagged";
        Finish_wall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall5.gameObject.tag = "Untagged";
        Finish_wall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall6.gameObject.tag = "Untagged";
        Finish_wall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall7.gameObject.tag = "Untagged";
        Finish_wall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall8.gameObject.tag = "Untagged";
        Finish_wall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Finish_wall9.gameObject.tag = "Untagged";
    }
    // Update is called once per frame
    void Update()
    {
        WallReset = B_WallTime + A_WallTime;

        timeSpan += Time.deltaTime;
        if (timeSpan < A_WallTime)
            AWall();
        if (timeSpan >= B_WallTime)
            BWall();

        if (timeSpan > WallReset)
            timeSpan = 0;
    }
}
