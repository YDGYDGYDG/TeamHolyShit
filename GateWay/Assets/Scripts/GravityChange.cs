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
    public bool IsGravity;
    public GameObject AlphaWallOn;

    // Start is called before the first frame update
    void Start()
    {
        IsGravity = true;
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsGravity) // 평상시 상황
        {
            rigid.gravityScale = 2;              // 그대로
        }
        if (!IsGravity) // 위로 올라가는 상황
        {
            rigid.gravityScale = -2;            // 올라가야지
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 반대로
        if (collision.gameObject.tag == "Lever") // 레버에 부딪치면
        {
            IsGravity = false;                   // 공중에 상승하는 상태로 바꿔주고
            AlphaWallOn.SetActive(true);         //뒤로 못가게 알파벽 세워주고
        }

        if (collision.gameObject.tag == "Gravity") // 중력레버에 부딪치면
        {
            IsGravity = true;                   // 중력 상태로 바꿔주고
            AlphaWallOn.SetActive(false);        // 알파벽 꺼주고
        }

        if (collision.gameObject.tag == "Trap")
        {
            IsGravity = false;
            AlphaWallOn.SetActive(false);
        }
    }
}
