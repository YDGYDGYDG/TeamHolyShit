using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRedController : MonoBehaviour
{
    public bool red;

    public GameObject redBox;

    GameObject box;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!red)
        {
            red = true;
            // 불덩이 프리팹 생성
            box = Instantiate(redBox) as GameObject;
            // 불덩이가 캐릭터를 따라다니네
            box.transform.position = transform.position;

        }
    }
}
