using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    public float jumpForce = 1000.0f;   // 점프에 전달할 힘 값
    public float walkForce = 10.0f;

    RaycastHit2D hit;

    EventSystem eventSystem;

    Animator animator;

    LayerMask moveLayerMask;

    float playerSize;


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

        hit = Physics2D.Raycast(transform.position, Vector2.up * -1, 100, moveLayerMask);
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && rigidBody.velocity.y == 0 && jump == false)
        {
            jump = true;
            rigidBody.AddForce(transform.up * jumpForce);
            
        }
        if (hit.distance > playerSize)
        {
            jump = true;
        }
        else if(hit.distance <= playerSize)
        {
            jump = false;
        }


        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.A) && jump == false)
        {
            rigidBody.AddForce(transform.right * -1 * walkForce);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 오른쪽으로 이동
        if (Input.GetKey(KeyCode.D) && jump == false)
        {
            rigidBody.AddForce(transform.right * 1 * walkForce);
            transform.localScale = new Vector3(1, 1, 1);
        }

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
            // transform.Translate(-0.05f, 0, 0);
            rigidBody.AddForce(transform.right * -1 * walkForce);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void RButtenDown()  // 오른쪽 버튼이 눌렸을 떄 실행
    {
        if(jump == false)
        {
            // transform.Translate(0.05f, 0, 0);
            rigidBody.AddForce(transform.right * 1 * walkForce);
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    public void JButtenDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        if (jump == false)
        {
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }


    bool select;            // 버튼이 눌러졌는지 아닌지 판단할 변수, false로 자동 초기화
    public void Swlwct()
    {
        select = true;
    }
    public void NotSwlwct()
    {
        select = false;

    }
}
