using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study06 : MonoBehaviour
{
    // 함수 유형
    // 함수 반환값이 있는가?
    // 함수 매개변수가 필요한가?

    // 1. 반환값도 매개변수도 없이 실행만 되는 함수

    // Start is called before the first frame update
    void Start()
    {
        int min = 1;
        int max = 2100000000;

        //int Silsoup(int min, int max)
        //{

        //    int result = Random.Range(10, 20);
        //    Debug.Log(min + "과 " + max + "사이의 임의값 :");
        //    temp = result;
        //    return 0;
        //}// 이런 애가 있어요

        //Silsoup(min, max);

        Debug.Log(min + "과 " + max + "사이의 임의값 :");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
