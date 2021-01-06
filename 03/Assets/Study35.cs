using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Study35 : MonoBehaviour
{
    int A = 5;
    void Chat()
    {
        Debug.Log("나는 멤버 함수다");
    }

    // Start is called before the first frame update
    void Start()
    {
        int A = 10;
        Debug.Log("Start의 로컬 변수 값은: " + A);
        Debug.Log(gameObject.name + "의 멤버 변수 값은: " + this.A);


        void Chat()
        {
            Debug.Log("나는 로컬 함수다");
        }

        Chat();
        this.Chat();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
