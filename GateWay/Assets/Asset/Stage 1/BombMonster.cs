using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMonster : MonoBehaviour
{
    public float movePower;     // 이동속도 기준(인스펙터에서 조절)

    Vector3 movement;
    public int movementFlag = 0;   // 0:정지, -1:왼쪽, 1:오른쪽
    bool isTracing;
    GameObject traceTarget;

    Rigidbody2D rigid;

    Vector3 monsterStartPosition = new Vector3();

    // Use this for initialization
    void Start()
    {
        StartCoroutine("ChangeMovement");
        rigid = GetComponent<Rigidbody2D>();
        monsterStartPosition = transform.position;
    }

    IEnumerator ChangeMovement()    // 3초마다 반복 실행 코루틴
    {
        // 이동방향 랜덤 전환
        movementFlag = Random.Range(-1, 2);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 대기 후 다시 실행
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void FixedUpdate()  // 과부하를 최소화 하기 위해 Fixed로 실행했음
    {
        Move();
    }

    string dist = "";

    void Move()     // 이동 로직 시스템
    {
        Vector3 moveVelocity = Vector3.zero;

        

        // 플레이어 인식범위 존재 판단
        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (movementFlag == -1)
                dist = "Left";
            else if (movementFlag == 1)
                dist = "Right";
        }


        // 플래그가 왼쪽이 나오면
        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
        // 플래그가 오른쪽이 나오면
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }


        // '기본 이동속도'
        movement = transform.position += moveVelocity * movePower * Time.deltaTime;

        // 플레이어가 범위 내에 있을때
        if (isTracing == true)
        {
            // 이동속도 증가
            movement = transform.position += moveVelocity * (movePower * 5.0f) * Time.deltaTime;
        }
        // 플레이어가 범위 내에 없을때
        else if (isTracing == false)
        {
            // 원래 이동속도로
            movement = transform.position += moveVelocity * movePower * Time.deltaTime;
        }


        // 바닥이 있는지 체크
        Vector2 frontVec = new Vector2(rigid.position.x + (movementFlag * 0.4f), rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 2, LayerMask.GetMask("Wall"));


        // 바닥이 없네???
        if (rayHit.collider == null)
        {
            // 왼쪽 이동중일때 바닥이 없다?
            if (dist == "Left")
            {
                // 오른쪽으로 방향 전환
                movementFlag = 1;
            }

            // 오른쪽 이동중일때 바닥이 없다?
            else if (dist == "Right")
            {
                // 왼쪽으로 방향 전환
                movementFlag = -1;
            }
        }
    }



    // 플레이어가 인식범위 내 진입 시 시퀀스
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }

        
    }

    // 플레이어가 범위 안에 있을 때 시퀀스
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;   // 플레이어 추격

            // 바닥이 있는지 체크
            Vector2 frontVec = new Vector2(rigid.position.x + movementFlag, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 2, LayerMask.GetMask("Wall"));

            if(rayHit.collider == null)
            {
                // 바닥이 없으면 처음 저장된 포지션 값으로 이동
                transform.position = monsterStartPosition;
            }
        }



    }

    // 플레이어가 범위 밖으로 벗어날 때 시퀀스
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }
}
