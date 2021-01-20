using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{

    private CapsuleCollider2D capsule; // 충돌 처리해주기 위한 컴포넌트
   

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "diswall")
        {
            Debug.Log("제발실행해젭ㄷㄱㄹ ㅓㅐㅇ");
            Destroy(collision.gameObject, 1);
            GameObject.Find("player").GetComponent<HookShotScript>().HookOFF();
        }
    }
}
