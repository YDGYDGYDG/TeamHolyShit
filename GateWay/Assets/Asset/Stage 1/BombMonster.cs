using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMonster : MonoBehaviour
{
    public float movePower;     // 이동속도 기준(인스펙터에서 조절)

    Vector3 movement;
    int movementFlag = 0;   // 0:정지, 1:왼쪽, 2:오른쪽
    bool isTracing;
    GameObject traceTarget;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()    // 3초마다 반복 실행 코루틴
    {
        // 이동방향 랜덤 전환
        movementFlag = Random.Range(0, 3);

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

    void Move()     // 이동 로직 시스템
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

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
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2)
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


        // 최종 이동속도 계산
        transform.position += moveVelocity * movePower * Time.deltaTime;
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
            isTracing = true;
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
