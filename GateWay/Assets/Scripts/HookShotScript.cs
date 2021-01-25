using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HookShotScript : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;

    Rigidbody2D getRigid;

    // 현재 훅 조건
    // 훅이 사용중인가
    public bool isHookActive;
    // 훅이 최대 길이만큼 늘어났는가
    public bool isLineMax;
    // 훅이 어딘가에 연결되었는가
    public bool isAttach;

    // 로프 길이
    public float lineMax = 10;
    // 로프 날아가는 속도
    public float lineSpeed = 30;
    // 로프 회수하는 속도
    public float linePullSpeed = 60;
    // 로프로 오브젝트 당기는 속도
    public float objectPullSpeed = 15;
    // 로프 끊었을 때 받는 힘
    public int linePower = 100;
    // 로프 길이에 의해 받은 힘의 차이 (로프 탄성 계수)
    public float linePowerRate = 1.0f;


    // 현재 로프의 최대 길이
    public float ropeLength;

    DistanceJoint2D hookJoint2D;

    public bool isAttachWall;
    public bool isAttachObject;

    public GameObject hookedObject;
    public float hookedObjectSize;

    Animator jumpAnim;                  // 줄 생성 중일 때 점프 애니메이션 전환용(형준)
    SpriteRenderer playerPosition;      // 캐릭터 이동방향 판단(형준)
    GameObject HookSE;                  // 훅 SE 재생용(형준)
    

    // 에임 표시
    public GameObject aim;
    public Vector2 aimDir;
    public Vector2 shootDir;

    int aimLayerMask;

    // UI 사용
    public GameObject HookOffBtn;

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

        playerPosition = GetComponent<SpriteRenderer>();    // 랜더러 값 찾아주고?(형준)
        HookSE = GameObject.Find("Hook");                   // 훅 찾아주고..(형준)

        aimLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
    }

    void Update()
    {

        // '줄'의 시작점은 캐릭터의 위치로 고정
        line.SetPosition(0, transform.position);
        // 줄의 끝점은 훅의 위치로 고정
        line.SetPosition(1, hook.position);

        // 훅 처리=============================================================================
        // 훅과 연결된 캐릭터 처리-------------------------------------------------------------
        // 훅이 박혔는지 판단
        if (isAttach)
        {
            // 훅이 벽에 박혔다
            if (isAttachWall)
            {
                // 캐릭터가 중력을 받지 않게됨
                getRigid.gravityScale = 0;
                // 이전에 받고 있던 힘 삭제
                getRigid.velocity = Vector2.zero;

                // 이제 캐릭터를 훅 방향으로 움직인다.(훅의 조인트 길이를 줄인다.)
                // 처음에 빠르게, 가까워지면 천천히 줄어들어서 속도감
                if (hookJoint2D.distance > 1)
                {
                    hookJoint2D.distance -= Time.deltaTime * lineSpeed;
                    // 뭐? 다 줄였는데 훅이랑 캐릭터랑 멀리있다고?
                    if ((hook.position - transform.position).magnitude > 1)
                    {
                        // 때려서라도 가^^
                        getRigid.AddForce(hook.position - transform.position);
                    }
                }
                // 다 줄어들었어?
                if ((hook.position - transform.position).magnitude <= 1)
                {
                    // 달랑거리지 마
                    //getRigid.simulated = false;
                    HookOFF();
                    float cuttedRopeLength = (transform.position - hook.position).magnitude;
                    float nowRope = ropeLength - cuttedRopeLength;
                    getRigid.AddForce((hook.position - transform.position).normalized * linePower * nowRope);

                }
            }

            // 훅이 오브젝트에 박혔다
            else if (isAttachObject)
            {
                hookJoint2D.enabled = false;
                // 오브젝트의 위치는 훅을 맞은 직후 표면에 훅을 붙힌 채로 딸려옴
                //hookedObject.transform.position = hook.position;

                // 후크와 오브젝트를 딱붙이는 컴포넌트를 활성화시킨다 
                hook.GetComponent<HingeJoint2D>().connectedBody = hookedObject.GetComponent<Rigidbody2D>();
                hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * objectPullSpeed);

                // 내 앞까지 이동했으면 줄 끊는다.
                if (Vector2.Distance(transform.position, hook.position) < hookedObjectSize)
                {
                    HookOFF();
                    hook.GetComponent<HingeJoint2D>().connectedBody = null;
                }
            }

        }

        // 훅 위치 처리-------------------------------------------------------------
        // 훅온일 때, 최대사거리아니고, 안붙었으면 = 날아감
        if (isHookActive && !isLineMax && !isAttach)
        {
            // 훅 날릴 때 몸 안딸려가게 하기
            hookJoint2D.enabled = false;

            hook.Translate(shootDir * Time.deltaTime * lineSpeed);
            if (Vector2.Distance(transform.position, hook.position) > lineMax)
            {
                isLineMax = true;
            }
        }
        // 훅온일 때, 최대사거리이고, 안붙었으면 = 돌아옴
        else if (isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * linePullSpeed);
            // 다 돌아왔으면
            if (Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                HookOFF();
            }
        }
    }

    public void HookOFF()
    {
        GetComponent<Animator>().SetBool("isJump", false);    // Idle 애니메이션 출력(형준)
        aim.SetActive(false);
        getRigid.simulated = true;
        getRigid.gravityScale = 1;
        isHookActive = false;
        isLineMax = false;
        isAttach = false;
        isAttachWall = false;
        isAttachObject = false;
        hook.gameObject.SetActive(false);
        HookOffBtn.SetActive(false);
    }

    public void HookOFFBtnTouch()
    {
        if (isAttachWall)
        {
            float cuttedRopeLength = (transform.position - hook.position).magnitude;
            float nowRope = ropeLength - cuttedRopeLength;
            getRigid.AddForce((hook.position - transform.position).normalized * linePower * nowRope);
        }
        HookOFF();
    }

    public void HookAim()
    {
        // 훅을 사용하지 않는 중이라면
        if (!isHookActive)
        {
            // 에임을 켜고
            aim.SetActive(true);
            // 에임 그리기 시퀀스 ---------------------
            // 에임의 끝점을 구하는 레이캐스트
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, aimDir, Mathf.Infinity, aimLayerMask);
            // 에임을 그린다
            // 에임의 레이캐스트 거리 > 에임의 최대 사거리 이면
            if (hit && lineMax > (transform.position - new Vector3(hit.point.x, hit.point.y, 0)).magnitude)
            {
                // 에임 위치는 레이캐스트 위치
                aim.transform.position = hit.point;
            }
            else
            {
                // 최대 사거리 위치 구하기
                Vector2 newAimPosition = new Vector2(transform.position.x, transform.position.y) + (lineMax * aimDir);
                // 에임 위치는 최대 사거리 위치
                aim.transform.position = newAimPosition;
            }
        }
    }

    public void HookShot()
    {
        if (!isHookActive)
        {
            aim.SetActive(false);
            GetComponent<Animator>().SetBool("isJump", true);    // 점프 애니메이션 출력(형준)

            hook.gameObject.SetActive(true);
            isHookActive = true;
            // 훅은 캐릭터 위치에서부터 날아가겠지
            hook.position = transform.position;
            //// 날아갈 방향은 포인터 방향
            //aimDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (aimDir.x < 0)        // 마우스 포인터 위치 판단(형준)
            {
                // 방향이 왼쪽일때(형준)
                playerPosition.flipX = true;     // 애니메이션 위치 왼쪽(형준)   
            }
            else
            {
                // 방향이 오른쪽일때(형준)
                playerPosition.flipX = false;     // 애니메이션 위치 오른쪽(형준)
            }
        }
    }

}
