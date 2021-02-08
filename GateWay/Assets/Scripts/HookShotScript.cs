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
    // 캐릭터 날아가는 속도
    [SerializeField, Range(0.1f, 0.5f)]
    private float playerlineSpeed = 0.2f;
    float playerlineSpeedPower = 1;
    [SerializeField, Range(0.00f, 0.1f)]
    private float playerlineSpeedRate = 0.02f;

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

    DistanceJoint2D hookChildJoint2D;

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
    int aimLayerMask1;

    // UI 사용
    public GameObject HookOffBtn;

    // 물건을 들고 있는가
    public bool isHaveShootableObject = false;
    public float shootPower = 1000;


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
        hookChildJoint2D = hook.GetChild(2).GetComponent<DistanceJoint2D>();

        playerPosition = GetComponent<SpriteRenderer>();    // 랜더러 값 찾아주고?(형준)
        HookSE = GameObject.Find("Hook");                   // 훅 찾아주고..(형준)
        jumpAnim = GetComponent<Animator>();         // 애니메이션 연결(형준)

        aimLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
        aimLayerMask1 = ~(1 << LayerMask.NameToLayer("Water"));


    }

    private void FixedUpdate()
    {
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
                if (Vector2.Distance(hook.position, transform.position) > 1f)
                {
                    // DIstance Joint 2D를 쓰지 말자
                    transform.position = Vector3.MoveTowards(transform.position, hook.position, playerlineSpeed * playerlineSpeedPower);
                    playerlineSpeedPower += playerlineSpeedRate;
                }
            }
        }
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
                // 다 줄어들었어?
                if (Vector2.Distance(hook.position, transform.position) <= 1f)
                {
                    // 달랑거리지 마
                    //getRigid.simulated = false;
                    HookOFF();
                    float cuttedRopeLength = Vector2.Distance(hook.position, transform.position);
                    float nowRope = ropeLength - cuttedRopeLength;
                    getRigid.AddForce((hook.position - transform.position).normalized * linePower * nowRope);
                }
            }

            // 훅이 오브젝트에 박혔다
            else if (isAttachObject)
            {
                // 오브젝트의 위치는 훅을 맞은 직후 표면에 훅을 붙힌 채로 딸려옴
                //hookedObject.transform.position = hook.position;

                // 후크와 오브젝트를 딱붙이는 컴포넌트를 활성화시킨다 
                hookChildJoint2D.connectedBody = hookedObject.GetComponent<Rigidbody2D>();
                hookChildJoint2D.distance = hookedObjectSize / 2;
                hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * objectPullSpeed);

                // 내 앞까지 이동했으면 줄 끊는다.
                if (Vector2.Distance(transform.position, hookedObject.transform.position) <= hookedObjectSize * 2)
                {
                    // 이 때, '던질 수 있는 오브젝트'를 가져왔으면 흡수한다
                    if (hookedObject.layer == LayerMask.NameToLayer("Shootable"))
                    {
                        // 가져온 오브젝트가 플레이어의 자식이 된다
                        hookedObject.transform.SetParent(transform);
                        // 그리고 머리위에 고정됨
                        hookedObject.transform.position = transform.position + (new Vector3(0, hookedObject.GetComponent<BoxCollider2D>().bounds.extents.y) + new Vector3(0, 0.4f, 0));
                        Rigidbody2D hookedObjectRigid = hookedObject.GetComponent<Rigidbody2D>();
                        hookedObject.GetComponent<BoxCollider2D>().enabled = false;
                        hookedObjectRigid.isKinematic = true;
                        hookedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        hookedObjectRigid.freezeRotation = true;
                        hookedObjectRigid.velocity = Vector2.zero;
                        // '나 물건 들고 있어요'가 true
                        isHaveShootableObject = true;
                        // 애니메이션도 바꿔줘(형준)
                        GetComponent<Animator>().SetBool("isJump", true);
                    }
                    HookOFF();
                    hookChildJoint2D.connectedBody = null;
                }
            }

        }

        // 훅 위치 처리-------------------------------------------------------------
        // 훅온일 때, 최대사거리아니고, 안붙었으면 = 날아감
        if (isHookActive && !isLineMax && !isAttach)
        {
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
        aim.SetActive(false);
        //getRigid.simulated = true;
        getRigid.gravityScale = 2;
        isHookActive = false;
        isLineMax = false;
        isAttach = false;
        isAttachWall = false;
        isAttachObject = false;
        hook.gameObject.SetActive(false);
        HookOffBtn.SetActive(false);
        playerlineSpeedPower = 1;
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
        // 물건을 들고 있는 중일 때라면
        if (isHaveShootableObject)
        {
            // 에임을 켜고
            aim.SetActive(true);
            if (aimDir.y < 0)
            {
                if(aimDir.x > 0)
                {
                    aimDir.x = 1;
                }
                else aimDir.x = -1;
                aimDir.y = 0;
            }
            aim.transform.position = new Vector2 (hookedObject.transform.position.x, hookedObject.transform.position.y) + (3 * aimDir);
        }
        else
        {
            // 훅을 사용하지 않는 중이라면
            if (!isHookActive)
            {
                // 에임을 켜고
                aim.SetActive(true);
                // 에임 그리기 시퀀스 ---------------------
                // 에임의 끝점을 구하는 레이캐스트
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position, aimDir, Mathf.Infinity, aimLayerMask & aimLayerMask1);
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
    }

    public void HookShot()
    {
        if (!isHookActive)
        {
            aim.SetActive(false);
            
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


    public void ShootObject()
    {
        aim.SetActive(false);
        BreakShootableObject();
        // 애니메이션 원래대로(형준)
        GetComponent<Animator>().SetBool("isJump", false);
        // 오브젝트 날리기
        if (shootDir.y < 0)
        {
            if (shootDir.x > 0)
            {
                shootDir.x = 1;
            }
            else shootDir.x = -1;
            shootDir.y = 0;
        }
        hookedObject.GetComponent<Rigidbody2D>().AddForce(shootDir * shootPower);
    }
    public void BreakShootableObject()
    {
        isHaveShootableObject = false;

        // 물리 효과 다시 받게 함
        if (hookedObject.GetComponent<BoxCollider2D>())
            hookedObject.GetComponent<BoxCollider2D>().enabled = true;
        hookedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        hookedObject.GetComponent<Rigidbody2D>().freezeRotation = false;

        // 들고있던 오브젝트를 자식에서 추방
        hookedObject.transform.SetParent(null);
    }
}
