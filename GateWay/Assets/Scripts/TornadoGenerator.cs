using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGenerator : MonoBehaviour
{
    public GameObject leftTornado_0;
    public GameObject leftTornado_1;
    public GameObject leftTornado_2;
    public GameObject rightTornado_0;
    public GameObject rightTornado_1;
    public GameObject rightTornado_2;
    public GameObject rightTornado_3;


    float timeSpan;  // 경과 시간
    float WindReset; // 바람 초기화
    float LeftWindTime = 3.0f;
    float RightWindTime = 3.0f;
    void Start()
    {
        leftTornado_0.gameObject.SetActive(false);
        leftTornado_1.gameObject.SetActive(false);
        leftTornado_2.gameObject.SetActive(false);
        rightTornado_0.gameObject.SetActive(false);
        rightTornado_1.gameObject.SetActive(false);
        rightTornado_2.gameObject.SetActive(false);
        rightTornado_3.gameObject.SetActive(false);

    }

    void rightTornado()
    {
        leftTornado_0.gameObject.SetActive(true);
        leftTornado_1.gameObject.SetActive(true);
        leftTornado_2.gameObject.SetActive(true);
        rightTornado_0.gameObject.SetActive(false);
        rightTornado_1.gameObject.SetActive(false);
        rightTornado_2.gameObject.SetActive(false);
        rightTornado_3.gameObject.SetActive(false);
  
    }

    void leftTornado()
    {
        leftTornado_0.gameObject.SetActive(false);
        leftTornado_1.gameObject.SetActive(false);
        leftTornado_2.gameObject.SetActive(false);
        rightTornado_0.gameObject.SetActive(true);
        rightTornado_1.gameObject.SetActive(true);
        rightTornado_2.gameObject.SetActive(true);
        rightTornado_3.gameObject.SetActive(true);
  
    }
    // Update is called once per frame
    void Update()
    {
        WindReset = LeftWindTime + RightWindTime;
        timeSpan += Time.deltaTime;

        if (timeSpan < LeftWindTime)
            leftTornado();
        if (timeSpan >= RightWindTime)
            rightTornado();
        if (timeSpan > WindReset)
            timeSpan = 0;
    }
}
