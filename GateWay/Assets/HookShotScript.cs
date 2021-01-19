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
    public int lineSpeed;

    void Start()
    {
        getRigid = gameObject.GetComponent<Rigidbody2D>();

        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;

        hook.gameObject.SetActive(false);
    }

    void Update()
    {
        // 고리가 박힌 상태가 아닌 동안
        if (!isAttach)
        {
            getRigid.gravityScale = 1;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hook.position);
        }

        // 후크오프, 누르면 쏨
        if (Input.GetMouseButtonDown(0) && !isHookActive)
        {
            hook.gameObject.SetActive(true);
            isHookActive = true;
            hook.position = transform.position;
            shootDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        // 후크온, 붙음 = 두 번째 누르면 끊음
        else if (Input.GetMouseButtonDown(0) && isHookActive && isAttach)
        {
            line.SetPosition(1, transform.position);
            isHookActive = false;
            isAttach = false;
            hook.gameObject.SetActive(false);
        }

        // 후크온, 최대사거리아님, 안붙음 = 늘어남
        if (isHookActive && !isLineMax && !isAttach)
        {
            hook.Translate(shootDir.normalized * Time.deltaTime * lineSpeed);

            if(Vector2.Distance(transform.position, hook.position) > lineMax)
            {
                isLineMax = true;
            }
        }
        // 후크온, 최대사거리임, 안붙음 = 돌아옴
        else if (isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * lineSpeed*2);
            if(Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }

        // 고리가 박힌 상태면
        if (isAttach)
        {
            getRigid.gravityScale = 0;
            // 캐릭터를 후크 방향으로 움직여야 함
            // 줄도 캐릭터가 이동하는 만큼 줄어들어야 함
        }
    }
}
