using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HookShotScript hookLine;    // 훅 연결용 변수(형준)

    Rigidbody2D playerBody;     // 캐릭터 점프 할 때


    [SerializeField]            // 점프 함수 (김휘원)
    float power;                // 
    [SerializeField]            //
    Transform pos;              //
    [SerializeField]            //
    float checkRadius;          //
    [SerializeField]            //
    LayerMask islayer;          //

    bool isGround;


    // Start is called before the first frame update
    void Start()
    {

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 스크립트 연결(형준)

        playerBody = GetComponent<Rigidbody2D>();


    }
    // 캐릭터가 죽음
    public void PlayerDead()
    {
        Debug.Log("캐릭터 사망");
        this.gameObject.SetActive(false);     // 캐릭터 없애주고..(형준)
        hookLine.HookOFF();                   // 훅도 지워줘야지??(형준)
    }
    // Update is called once per frame
    void Update()
    {
        // 일단 점프기능인데 (김휘원)
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer) ;
        // 점프 키
        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.velocity = Vector2.up * power;
        }
    }

}
