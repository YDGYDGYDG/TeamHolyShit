using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;  //프리팹을 이용해 만들 객체
    GameObject arrow;   
    float span = 0.3f;
    float timeStack = 0;
    void Start()
    {

    }

    void Update()
    {
        if (timeStack > span) // span에서 지정한 값보다 커짐 (시간이 초과)
            timeStack = 0; // 축적된 시간을 초기화
        arrow = Instantiate(arrowPrefab) as GameObject;
        arrow.transform.position = new Vector3(20.0f, Random.Range(-3, -8), 0);
    }
}
