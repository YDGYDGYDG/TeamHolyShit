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
    public bool jump;
    bool stopJump; // 제자리
    // 버튼 스위치
    public bool LBTrigger;
    public bool RBTrigger;

    HookShotScript player;


    //EventSystem eventSystem;
    

    SpriteRenderer playerPosition;      // 애니메이션 방향 판단(형준)
    Animator animator;                  // 애니메이터(형준)

    AudioSource audioSource;            // SE 재생관리자(형준)
    PlayerState playerState;            // 캐릭터 상태 스크립트(형준)




    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        
        //eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        moveLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
        playerSize = gameObject.GetComponent<CircleCollider2D>().bounds.extents.magnitude;

        player = GetComponent<HookShotScript>();

        // 스프라이트 렌더러 연결(형준)
        playerPosition = GetComponent<SpriteRenderer>();
        // 애니메이터 연결(형준)
        animator = GetComponent<Animator>();
        // SE 재생관리자 연결(형준)
        audioSource = GetComponent<AudioSource>();
        // 캐릭터 상태 스크립트 연결(형준)
        playerState = GetComponent<PlayerState>();
    }

    void FixedUpdate()
    {
        // 키보드 이동 
        if (LBTrigger)
        {
            LBDown();
            playerPosition.flipX = true;    // 애니메이션 방향 왼쪽(형준)
            
        }
        if (RBTrigger)
        {
            RBDown();
            playerPosition.flipX = false;    // 애니메이션 방향 오른쪽(형준)
            
        }
    }

    private void Update()
    {
        // 키보드 이동
        if (Input.GetKeyDown(KeyCode.A))
        {
            LBtriggerON();
            playerPosition.flipX = true;    // 애니메이션 방향 왼쪽(형준)
            
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            LBtriggerOFF();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RBtriggerON();
            playerPosition.flipX = false;    // 애니메이션 방향 오른쪽(형준)  
            
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

      //  if (rigidBody.velocity.y == 0)   // 너 점프중이니?(형준)
      //  {
      //      animator.SetBool("isJump", false);  // Idle 애니메이션 출력(형준)
      //  }
      //  else if (rigidBody.velocity.y < 0 || rigidBody.velocity.y > 0)
      //  {
      //      
      //  }
        
    }

    public void LBtriggerON()
    {
        LBTrigger = true;
        animator.SetBool("isRun", true);    // 런 애니메이션 출력(형준)
        audioSource.clip = playerState.plyaerMove;  // 무브 클립(형준)
        audioSource.Play(); // SE 스탑(형준)
    }
    public void LBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(-transform.right * brakeForce);
        }
        LBTrigger = false;
        animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        audioSource.Stop(); // SE 스탑(형준)
    }
    public void RBtriggerON()
    {
        RBTrigger = true;
        animator.SetBool("isRun", true);    // 런 애니메이션 출력(형준)
        audioSource.clip = playerState.plyaerMove;  // 무브 클립(형준)
        audioSource.Play(); // SE 스탑(형준)

    }
    public void RBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(transform.right * brakeForce);
            
        }
        RBTrigger = false;
        animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        audioSource.Stop(); // SE 스탑(형준)
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
        }

    }


    public void JButtonDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        animator.SetBool("isRun", false);    // 런 애니메이션 정지(형준)
        audioSource.clip = playerState.plyaerjump;  // 점프 클립(형준)
        audioSource.Play();
        animator.SetBool("isJump", true);    // 점프 애니메이션 출력(형준)

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
    }

    public void Dead()
    {
        LBTrigger = false;
        RBTrigger = false;
    }
}
