using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjector : MonoBehaviour
{
    Vector2 laserDir;
    Vector2 laserPos;
    public LineRenderer line;
    int layerMask;
    int layerMask_ignore;
    RaycastHit2D hit;

    void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Mirror");
        layerMask_ignore = 1 << LayerMask.NameToLayer("LaserProjector");
        layerMask_ignore = ~layerMask_ignore;
        line.positionCount = 1;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.useWorldSpace = true;
    }

    void Update()
    {
        line.positionCount = 1;
        laserDir = transform.right;
        laserPos = transform.position;

        line.positionCount++;
        //hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity);
        hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
        if (hit) line.SetPosition(line.positionCount - 1, hit.point);
        else line.SetPosition(line.positionCount - 1, transform.position);

        while (hit && line.positionCount < 50) 
        {
            line.positionCount++;
            laserPos = hit.point - (laserDir.normalized);
            laserDir = Vector2.Reflect(laserDir, hit.normal);
            //hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity);
            hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask);
            if (hit)
                line.SetPosition(line.positionCount - 1, hit.point);
            else
                line.positionCount--;
        }

    }


}
