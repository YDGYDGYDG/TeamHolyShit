using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "diswall")
        {
            Debug.Log("되라");
            Destroy(collision.gameObject, 1);
        }
    }
}