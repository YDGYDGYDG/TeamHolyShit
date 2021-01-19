﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotScript : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;

    Vector2 shootDir;

    Rigidbody2D getRigid;

    public bool isHookActive;
    public bool isLineMax;
    public bool isAttach;

    public int lineMax;
    public float lineSpeed;

    DistanceJoint2D hookJoint2D;

    void Start()
    {
        getRigid = gameObject.GetComponent<Rigidbody2D>();

        // 줄 생성
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;

        hook.gameObject.SetActive(false);
        hookJoint2D = hook.GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        // '줄'의 시작점은 캐릭터의 위치로 고정
        line.SetPosition(0, transform.position);
        // 줄의 끝점은 훅의 위치로 고정
        line.SetPosition(1, hook.position);


        // 훅이 벽에 박혔으면
        if (isAttach)
        {
            // 캐릭터가 중력을 받지 않게됨
            getRigid.gravityScale = 0;
            // 힘 삭제
            getRigid.velocity = Vector2.zero;

            // 이제 캐릭터를 훅 방향으로 움직인다.(훅의 조인트 길이를 줄인다.)
            // 처음에 빠르게, 가까워지면 천천히 줄어들어서 속도감
            if (hookJoint2D.distance > 1)
            {
                hookJoint2D.distance -= Time.deltaTime * lineSpeed;
                // 뭐? 다 줄였는데 훅이랑 캐릭터랑 멀리있다고?
                if((hook.position - transform.position).magnitude > 1)
                {
                    // 때려서라도 가^^
                    getRigid.AddForce(hook.position - transform.position);
                }
            }
            // 다 줄어들었어?
            if ((hook.position - transform.position).magnitude <= 1)
            {
                // 달랑거리지 마
                getRigid.simulated = false;
            }
        }

        // 훅오프일 때, 누르면 쏜다. 
        if (Input.GetMouseButtonDown(0) && !isHookActive)
        {

            hook.gameObject.SetActive(true);
            isHookActive = true;
            // 훅은 캐릭터 위치에서부터 날아가겠지
            hook.position = transform.position;
            // 날아갈 방향은 포인터 방향
            shootDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        // 훅온일 때, 붙은 상태이면, 누르면 끊는다.
        else if (Input.GetMouseButtonDown(0) && isHookActive && isAttach)
        {
            HookOFF();
        }

        // 훅온일 때, 최대사거리아니고, 안붙었으면 = 늘어남
        if (isHookActive && !isLineMax && !isAttach)
        {
            // 훅 날릴 때 몸 안딸려가게 하기
            hookJoint2D.enabled = false;

            hook.Translate(shootDir.normalized * Time.deltaTime * lineSpeed);
            if(Vector2.Distance(transform.position, hook.position) > lineMax)
            {
                isLineMax = true;
            }
        }
        // 훅온일 때, 최대사거리이고, 안붙었으면 = 돌아옴
        else if (isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * lineSpeed*2);
            // 다 돌아왔으면
            if(Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                HookOFF();
            }
        }
    }

    void HookOFF()
    {
        getRigid.simulated = true;
        getRigid.gravityScale = 1;
        isHookActive = false;
        isLineMax = false;
        isAttach = false;
        hook.gameObject.SetActive(false);
    }
}
