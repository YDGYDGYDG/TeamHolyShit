using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    Rigidbody2D rigid;
    float timeSpan;  // 경과 시간
    float WindReset; // 바람 초기화
    float LeftWindTime = 3.0f;
    float RightWindTime = 3.0f;

    public void RightWind()
    {
        rigid.AddForce(Vector3.right * 0.4f, ForceMode2D.Impulse);
    }
    public void LeftWind()
    {
        rigid.AddForce(Vector3.left * 0.4f, ForceMode2D.Impulse);
    }
    public void UpWind()
    {
        rigid.AddForce(Vector3.up * 0.4f, ForceMode2D.Impulse);
    }
    public void DownWind()
    {
        rigid.AddForce(Vector3.down * 0.4f, ForceMode2D.Impulse);
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        timeSpan = 0.0f;     
    }

    void Update()
    {
        WindReset = RightWindTime + LeftWindTime;

        timeSpan += Time.deltaTime;
        if (timeSpan < LeftWindTime)
        LeftWind();
        if (timeSpan >= RightWindTime)
        RightWind();
        if (timeSpan > WindReset)
        timeSpan = 0;
    } 
}
