using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    public float jumpForce = 1500.0f;   // 점프에 전달할 힘 값
    public float brakeForce = 100.0f;    // 브레이크 힘
    public float jumpSpeed = 600.0f;    // 이동 점프 스피드
    public float speed = 0.01f; // 이속

    // =============================================
    // 점프 변수
    // 바닥에 닿았는지 판단
    RaycastHit2D LHit;
    RaycastHit2D RHit;
    LayerMask moveLayerMask;
    float playerSize;
    // 점프 상태
    bool jump;
    bool stopJump; // 제자리
    bool moveJump; // 움직이는 도중
    // 버튼 스위치
    bool LBTrigger;
    bool RBTrigger;

    HookShotScript player;


    //EventSystem eventSystem;
    //Animator animator;


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        //animator = gameObject.GetComponent<Animator>();
        //eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        moveLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
        playerSize = gameObject.GetComponent<CircleCollider2D>().bounds.extents.magnitude;

        player = GetComponent<HookShotScript>();
    }

    void FixedUpdate()
    {
        // 키보드 이동 
        if (LBTrigger)
        {
            LBDown();
        }
        if (RBTrigger)
        {
            RBDown();
        }
    }

    private void Update()
    {
        // 키보드 이동
        if (Input.GetKeyDown(KeyCode.A))
        {
            LBtriggerON();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            LBtriggerOFF();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RBtriggerON();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            RBtriggerOFF();
        }


        // 점프 검사
        LHit = Physics2D.Raycast(transform.position + new Vector3(playerSize, -0.13f), Vector2.down, Mathf.Infinity, moveLayerMask);
        RHit = Physics2D.Raycast(transform.position + new Vector3(-playerSize, -0.13f), Vector2.down, Mathf.Infinity, moveLayerMask);
        if (LHit.distance > playerSize && RHit.distance > playerSize)
        {
            jump = true;
        }
        else if (LHit.distance <= playerSize || RHit.distance <= playerSize)
        {
            ResetMovement();
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            JButtonDown();
        }
        // 제자리 점프 상태
        if (rigidBody.velocity.x == 0 && jump == true)
        {
            stopJump = true;
        }
    }

    public void LBtriggerON()
    {
        LBTrigger = true;
    }
    public void LBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(-transform.right * brakeForce);
        }
        LBTrigger = false;
    }
    public void RBtriggerON()
    {
        RBTrigger = true;
    }
    public void RBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(transform.right * brakeForce);
        }
        RBTrigger = false;
    }


    public void LBDown()
    {
        if (player.isAttachWall) 
        {
            ResetMovement();
        }
        else
        {
            if (jump == false && stopJump == false)
            {
                transform.Translate(-speed, 0, 0);

            }
            else if (jump == true && stopJump == true)
            {
                stopJump = false;

                rigidBody.AddForce(-transform.right * brakeForce);

            }
            else if (moveJump == false)
            {
                moveJump = true;

                rigidBody.AddForce(-transform.right * brakeForce);

            }

        }

    }
    public void RBDown()
    {
        if (player.isAttachWall)
        {
            ResetMovement();
        }
        else
        {
            if (jump == false && stopJump == false)
            {
                transform.Translate(speed, 0, 0);
            }
            else if (jump == true && stopJump == true)
            {
                stopJump = false;
                rigidBody.AddForce(transform.right * brakeForce);

            }
            else if (moveJump == false)
            {
                moveJump = true;
                rigidBody.AddForce(transform.right * brakeForce);
            }

        }

    }


    public void JButtonDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        if (LBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(-1, 2).normalized;
            rigidBody.AddForce(LJ * jumpForce);
        }
        else if (RBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(1, 2).normalized;
            rigidBody.AddForce(LJ * jumpForce);
        }
        else if (!jump)
        {
            stopJump = true;
            jump = true;
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }

    
    void ResetMovement()
    {
        jump = false;
        stopJump = false;
        moveJump = false;
    }

    public void Dead()
    {
        LBTrigger = false;
        RBTrigger = false;
    }
}
