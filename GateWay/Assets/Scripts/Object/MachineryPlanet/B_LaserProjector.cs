﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_LaserProjector : MonoBehaviour
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
            // 센서에 레이저가 닿으면
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("LaserCensor"))
            {
                // 현상 발생 처리
                //Debug.Log("발동!");

            }
        }
        else line.SetPosition(line.positionCount - 1, transform.position);

        while (hit.collider.gameObject.layer == 8 && line.positionCount < 50)
        {
            line.positionCount++;
            laserPos = hit.point - (laserDir.normalized);
            laserDir = Vector2.Reflect(laserDir, hit.normal);
            hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
            if (hit)
                line.SetPosition(line.positionCount - 1, hit.point);
            else
                line.positionCount--;
        }

    }


}
