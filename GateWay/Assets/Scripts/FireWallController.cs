using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallController : MonoBehaviour
{
    Vector2 laserPos;
    Vector2 laserDir;

    public LineRenderer line;

    int layerMask;

    RaycastHit2D hit;

    BoxCollider2D fireCollider;

    float fireHigh = 10.0f; // 불기둥 높이
    float fireSize;         // y의 충돌 크기

    public float hitPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        //layerMask = 2 << LayerMask.NameToLayer("Wall");
        layerMask = LayerMask.GetMask("Wall");
        line.positionCount = 2;
        line.endWidth = 1.0f;                       // 라인 렌더러 크기
        line.startWidth = 1.0f;
        line.SetPosition(0, transform.position);    // 첫 번째 점
        line.useWorldSpace = true;                  // 활성화 하냐 비 활성화 하냐
        
    }
    float fireOffset;
    // Update is called once per frame
    void Update()
    {
        
        laserDir = transform.up;        // 방향
        laserPos = transform.position;  // 위치

        // 해당 오브젝트 위치에서 위로 100의 거리만큼 쏘는데 레이어가 마스크만 충돌
        hit = Physics2D.Raycast(laserPos, laserDir, fireHigh, layerMask);

        if (hit)
        {
            line.SetPosition(1, hit.point);                             // 충돌하면 거기가 새로운 점
            hitPoint = hit.point.y - transform.position.y ;
            //Debug.Log(hitPoint);
        }                       
        else
        {
            line.SetPosition(1, laserPos + new Vector2(0f, fireHigh));  // 안하면 현재 위치에서 100 떨어진 곳
            hitPoint = (transform.position.y + fireHigh)- transform.position.y;
          
        }
        
    }

}
