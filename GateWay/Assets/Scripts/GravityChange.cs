using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    Rigidbody2D rigid;
    float GravityTime = 1.5f;
    float NonGravityTime = 1.5f;
    float timeSpan;  // 경과 시간
    float GravityReset; // 중력 초기화시간
    public bool GravityStart = false;
    public GameObject AlphaWallOn;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GravityStart)
        {
            GravityReset = GravityTime + NonGravityTime;
            timeSpan += Time.deltaTime;
            if (timeSpan < GravityTime)
            {
                rigid.gravityScale = -1;
            }
            if (timeSpan >= NonGravityTime)
            {
                rigid.gravityScale = 1;
            }
            if (timeSpan > GravityReset)
                timeSpan = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            GravityStart = true;
            AlphaWallOn.SetActive(true);
        }
        if (collision.gameObject.tag == "Trap")
        {
            GravityStart = false;
            AlphaWallOn.SetActive(false);
        }
    }
}
