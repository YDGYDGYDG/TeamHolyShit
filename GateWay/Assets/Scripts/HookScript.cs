using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    HookShotScript hookShot;
    DistanceJoint2D joint2D;

    void Start()
    {
        hookShot = GameObject.Find("player").GetComponent<HookShotScript>();
        joint2D = GetComponent<DistanceJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 훅이 벽에 닿으면
        if (collision.CompareTag("Wall"))
        {
            joint2D.enabled = true;
            // 이제부터 그 거리가 고정됩니다.
            // 이 거리를 0.005까지 점차 줄이면 캐릭터가 훅 방향으로 가까워지겠지
            //joint2D.autoConfigureDistance = false;
            hookShot.isAttach = true;
        }
    }

}
