using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindJump : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;
    public float power = 20f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpWind")
        {
            rigid.AddForce(Vector3.up * power, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "DownWind")
        {
            rigid.AddForce(Vector3.down * power, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "RightWind")
        {
            rigid.AddForce(Vector3.right * power, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "LeftWind")
        {
            rigid.AddForce(Vector3.left * power, ForceMode2D.Impulse);
        }
    }
 
}
