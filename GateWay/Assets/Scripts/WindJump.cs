using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindJump : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpWind")
        {
            rigid.AddForce(Vector3.up * 40f, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "DownWind")
        {
            rigid.AddForce(Vector3.down * 40f, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "RightWind")
        {
            rigid.AddForce(Vector3.right * 40f, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "LeftWind")
        {
            rigid.AddForce(Vector3.left * 40f, ForceMode2D.Impulse);
        }
    }
}
