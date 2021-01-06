using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study43 : MonoBehaviour
{
    public GameObject outletSample;

    GameObject otherObject;

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 명으로 오브젝트를 가져올 수 있다
        otherObject = GameObject.Find("Study43_Sample");
        // 이때 활성화되지 않은 오브젝트는 가져올 수 없다.
        Debug.Log(otherObject.name);


        // 오브젝트 배열도 역시 가능
        GameObject[] objects;
        // 이름으로 모든 오브젝트 찾아서 넣기
        objects = GameObject.FindGameObjectsWithTag("Cube");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
