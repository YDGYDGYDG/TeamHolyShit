using System.Collections;
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

    public bool isAttachWall;
    public bool isAttachObject;

    public GameObject hookedObject;

    GameObject player;    // 플레이어 연결(형준)
    Animator jumpAnim;    // 줄 생성 중일 때 점프 애니메이션 전환용(형준)
    Vector2 Mouseposition;  // 줄 생성 위치 좌표 판단(형준)
    SpriteRenderer playerPosition;      // 캐릭터 이동방향 판단(형준)


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

        player = GameObject.Find("player");   // 일단 플레이어 찾고(형준)
        playerPosition = GetComponent<SpriteRenderer>();    // 랜더러 값 찾아주고?(형준)
     
        
        
    }

    void Update()
    {
        

        // '줄'의 시작점은 캐릭터의 위치로 고정
        line.SetPosition(0, transform.position);
        // 줄의 끝점은 훅의 위치로 고정
        line.SetPosition(1, hook.position);


        // 훅이 박혔으면
        if (isAttach)
        {
            // 훅이 벽에 박혔으면
            if (isAttachWall)
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
                    getRigid.simulated = false;
                }
            }
            // 훅이 오브젝트에 박혔으면
            else if (isAttachObject)
            {
                hookJoint2D.enabled = false;
                hookedObject.transform.position = hook.position;
                hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * lineSpeed / 2);
                // 다 돌아왔으면
                if (Vector2.Distance(transform.position, hook.position) < 1f)
                {
                    HookOFF();
                }
            }
        }

        // 훅오프일 때, 누르면 쏜다. 
        if (Input.GetMouseButtonDown(0) && !isHookActive)
        {
            player.GetComponent<Animator>().SetBool("isJump", true);    // 점프 애니메이션 출력(형준)

            GetComponent<AudioSource>().Play();     // 훅 사운드 재생(형준)

            hook.gameObject.SetActive(true);
            isHookActive = true;
            // 훅은 캐릭터 위치에서부터 날아가겠지
            hook.position = transform.position;
            // 날아갈 방향은 포인터 방향
            shootDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;



            this.Mouseposition = shootDir;  // shootDir 값 대입(형준)
            
            if (Mouseposition.x < 0)        // 마우스 포인터 위치 판단(형준)
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
        // 훅온일 때, 벽에 붙은 상태이면, 누르면 끊는다.
        else if (Input.GetMouseButtonDown(0) && isHookActive && isAttachWall)
        {
            HookOFF();
            // 줄이 남은 상태에서 끊었으면 가던 방향으로 날라감
            if ((hook.position - transform.position).magnitude > 1)
                getRigid.AddForce((hook.position - transform.position).normalized * 1000);
        }
        // 훅온일 때, 오브젝트에 붙은 상태이면, 누르면 끊는다.
        else if (Input.GetMouseButtonDown(0) && isHookActive && isAttachObject)
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

    public void HookOFF()
    {
        player.GetComponent<Animator>().SetBool("isJump", false);    // Idle 애니메이션 출력(형준)

        getRigid.simulated = true;
        getRigid.gravityScale = 1;
        isHookActive = false;
        isLineMax = false;
        isAttach = false;
        isAttachWall = false;
        isAttachObject = false;
        hook.gameObject.SetActive(false);
    }
}
