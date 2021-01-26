using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_LaserProjector : MonoBehaviour
{
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
            if(hit.collider.gameObject.tag == "Player")
            {
                // 플레이어 죽음 처리
                //Debug.Log("쥬금");
            }
        }
        else line.SetPosition(line.positionCount - 1, transform.position);
        
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


}
