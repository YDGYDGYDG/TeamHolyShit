using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_LaserProjector : MonoBehaviour
{
    PlayerState player;

    Vector2 laserDir;
    Vector2 laserPos;
    public LineRenderer line;
    int layerMask_ignore;
    RaycastHit2D hit;

    void Awake()
    {
        layerMask_ignore = 1 << LayerMask.NameToLayer("LaserProjector");
        layerMask_ignore = ~layerMask_ignore;
        line.positionCount = 1;
        line.endWidth = line.startWidth = 0.2f;
        line.SetPosition(0, transform.position);
        line.useWorldSpace = true;

        player = GameObject.Find("player").GetComponent<PlayerState>();
    }

    void Update()
    {
        line.positionCount = 1;
        laserDir = transform.right;
        laserPos = transform.position;

        line.positionCount++;
        hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
        if (hit)
        {
            line.SetPosition(line.positionCount - 1, hit.point);
            // 플레이어가 레이저에 닿으면
            if (hit.collider.gameObject.tag == "Player")
            {
                // 플레이어 죽음 처리
                player.PlayerDead();
            }
                while (hit.collider.gameObject.layer == LayerMask.NameToLayer("Mirror") && line.positionCount < 50)
            {
                laserPos = hit.point - (laserDir.normalized * 0.0001f);
                laserDir = Vector2.Reflect(laserDir, hit.normal);
                hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
                if (hit)
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, hit.point);
                }
            }

        }
        else line.SetPosition(line.positionCount - 1, transform.position);

        // 기계행성은 무조건 벽으로 둘러싸서 레이저가 어딘가에 부딪히게 하자
        //// 걸리는 게 없으면 그냥 멀리멀리 그려라
        //else
        //{

        //}
    }
}
