using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    public float jumpForce = 1000.0f;   // 점프에 전달할 힘 값
    public float brakeForce = 100.0f;    // 브레이크 힘
    public float jumpSpeed = 600.0f;    // 이동 점프 스피드

    RaycastHit2D hit;

    EventSystem eventSystem;

    Animator animator;

    LayerMask moveLayerMask;

    float playerSize;

    bool stopJump; // 제자리 점프 상태

    bool moveJump;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        moveLayerMask = ~(1 << LayerMask.NameToLayer("Player"));

        playerSize = gameObject.GetComponent<CircleCollider2D>().bounds.extents.magnitude + 0.13f;
    }
    bool jump;

    // Update is called once per frame
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
        // 왼쪽으로 이동
        if (Input.GetKeyDown(KeyCode.A))
        {
            LBtriggerON();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            LBtriggerOFF();
        }

        // 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.D))
        {
            RBtriggerON();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            RBtriggerOFF();
        }
        //======================점프===========================================================
        hit = Physics2D.Raycast(transform.position, Vector2.up * -1, 200, moveLayerMask);
        // 점프 상태
        if (hit.distance > playerSize)
        {
            jump = true;
        }

        else if (hit.distance <= playerSize)
        {
            jump = false;
            stopJump = false;
            moveJump = false;
        }

        // 이동 점프
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && jump == false)
        {
            JButtonDown();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && jump == false)
        {
            JButtonDown();
        }
        // 제자리 점프
        else if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            JButtonDown();
        }

        // 제자리 점프 상태
        if (rigidBody.velocity.x == 0 && jump == true)
        {
            stopJump = true;
        }
    }

    public float speed = 0.01f;
    // 키보드 이동
    public void LBDown()
    {
        if (jump == false && stopJump == false)
        {
            transform.Translate(speed * -1, 0, 0);

        }
        else if(jump == true && stopJump == true)
        {
            stopJump = false;

            rigidBody.AddForce(transform.right * -1 * brakeForce);

        }
        else if(moveJump == false)
        {
            moveJump = true;

            rigidBody.AddForce(transform.right * -1 * brakeForce);

        }

    }
    public void RBDown()
    {
        if (jump == false && stopJump == false)
        {
            transform.Translate(speed, 0, 0);
        }
        else if(jump == true && stopJump == true)
        {
            stopJump = false;

            rigidBody.AddForce(transform.right * 1 * brakeForce);

        }
        else if (moveJump == false)
        {
            moveJump = true;

            rigidBody.AddForce(transform.right * 1 * brakeForce);
        }

    }


    public void JButtonDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        if (LBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(-0.5f, 1f);
            rigidBody.AddForce(LJ * jumpForce);
        }
        else if (RBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(0.5f, 1f);
            rigidBody.AddForce(LJ * jumpForce);
        }
        else if ( jump == false)
        {
            stopJump = true;
            jump = true;
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }


    // 왼쪽 버튼 스위치
    bool LBTrigger;            
    public void LBtriggerON()
    {
        LBTrigger = true;
    }
    public void LBtriggerOFF()
    {
        if (jump == false && stopJump == false)
        {
            rigidBody.AddForce(transform.right * -1 * brakeForce);
        }
        LBTrigger = false;
    }
    
    // 오른쪽 버튼 스위치
    bool RBTrigger;            
    public void RBtriggerON()
    {
        RBTrigger = true;
    }
    public void RBtriggerOFF()
    {
        if (jump == false && stopJump == false)
        {
            rigidBody.AddForce(transform.right * 1 * brakeForce);
        }
        
        RBTrigger = false;
    }
}
