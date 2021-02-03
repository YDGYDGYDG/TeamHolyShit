using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGreyController : MonoBehaviour
{
    public bool grey;

    public GameObject greyBox;

    GameObject box;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!grey)
        {
            grey = true;
            // 불덩이 프리팹 생성
            box = Instantiate(greyBox) as GameObject;
            // 불덩이가 캐릭터를 따라다니네
            box.transform.position = transform.position;

        }
    }
}
