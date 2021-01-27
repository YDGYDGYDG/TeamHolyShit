using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    public float jumpForce = 1200.0f;   // 점프에 전달할 힘 값
    public float walkForce = 50.0f;
    public float stopForce = 100.0f;    // 제자리 점프 이동
    public float jumpSpeed = 600.0f;

    RaycastHit2D hit;

    EventSystem eventSystem;

    Animator animator;

    LayerMask moveLayerMask;

    float playerSize;

    public float maxSpeed;

    bool stopJump;

    float addSpeed = 1;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        moveLayerMask = ~(1 << LayerMask.NameToLayer("Player"));

        playerSize = gameObject.GetComponent<CapsuleCollider2D>().bounds.extents.magnitude;
    }
    bool jump;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(addSpeed);

        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.A) && jump == false)
        {
            addSpeed += 0.5f;
            // rigidBody.AddForce(transform.right * -1 * (walkForce * addSpeed));
            transform.Translate(-0.05f, 0, 0);
 
            transform.localScale = new Vector3(-1, 1, 1);

            if (rigidBody.velocity.x < maxSpeed * -1f)
            {
                rigidBody.velocity = new Vector2(maxSpeed * -1, rigidBody.velocity.y);
            }
        }
        // 오른쪽 이동
        else if (Input.GetKey(KeyCode.D) && jump == false)
        {
            addSpeed += 0.5f;
            rigidBody.AddForce(transform.right * 1 * (walkForce*addSpeed));    // 힘을줄꼐

            transform.localScale = new Vector3(1, 1, 1);        // 방향을 바꿔

            if (rigidBody.velocity.x > maxSpeed)        // 너무 빠르잖아
            {
                rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
            }
        }
        else
        {
            addSpeed = 0;
        }

        // 이동속도 증가량 맥시멈
        if (addSpeed >= 10.0f)
        {
            addSpeed = 10.0f;
        }

        //======================점프===========================================================
        hit = Physics2D.Raycast(transform.position, Vector2.up * -1, 100, moveLayerMask);
        // 점프 상태
        if (hit.distance > playerSize)
        {
            jump = true;
        }
        else if (hit.distance <= playerSize)
        {
            jump = false;
            stopJump = false;
        }


        // 이동 점프
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.Space) && jump == false)
            {
                jump = true;
                rigidBody.AddForce(transform.up * jumpForce);
                rigidBody.AddForce(transform.right * 1 * jumpSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && jump == false)
        {
            Vector2 LJ = new Vector2(-0.5f, 1f);
            jump = true;
            rigidBody.AddForce(LJ * jumpForce);
            rigidBody.AddForce(transform.right * -1 * jumpSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            jump = true;
            rigidBody.AddForce(transform.up * jumpForce);

        }
        else if(Input.GetKeyDown(KeyCode.D) && stopJump == false && jump == true)
        {
            rigidBody.AddForce(transform.right * 1 * 100.0f);    // 힘을줄꼐

            transform.localScale = new Vector3(1, 1, 1);        // 방향을 바꿔

            stopJump = true;        // 한 번만 해줄께
        }
        else if(Input.GetKeyDown(KeyCode.A) && stopJump == false && jump == true)
        {
            rigidBody.AddForce(transform.right * -1 * 100.0f);

            transform.localScale = new Vector3(-1, 1, 1);

            stopJump = true;
        }



        // 버튼 UI 입출력 트리거
        if (select)
        {
            if (eventSystem.currentSelectedGameObject.name == "RButton")
            {
                RButtenDown();

            }
            else if (eventSystem.currentSelectedGameObject.name == "LButton")
            {
                LButtenDown();
            }
        }

    }


    public void LButtenDown()  // 왼쪽 버튼이 눌렸을 때 실행
    {
        if(jump == false)
        {
            rigidBody.AddForce(transform.right * -1 * walkForce);

            transform.localScale = new Vector3(-1, 1, 1);

            if (rigidBody.velocity.x < maxSpeed * -1f)
            {
                rigidBody.velocity = new Vector2(maxSpeed * -1, rigidBody.velocity.y);
            }
        }
    }


    public void RButtenDown()  // 오른쪽 버튼이 눌렸을 떄 실행
    {
        if(jump == false)
        {
            rigidBody.AddForce(transform.right * 1 * walkForce);    // 힘을줄꼐

            transform.localScale = new Vector3(1, 1, 1);        // 방향을 바꿔

            if (rigidBody.velocity.x > maxSpeed)        // 너무 빠르잖아
            {
                rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
            }
        }
    }


    public void JButtenDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        if (jump == false)
        {
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }

    // 버튼이 눌러졌는지 아닌지 판단할 변수, false로 자동 초기화
    bool select;            
    public void Swlwct()
    {
        select = true;
    }
    public void NotSwlwct()
    {
        select = false;

    }
}
