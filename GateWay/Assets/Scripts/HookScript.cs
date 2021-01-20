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
        if (!hookShot.isLineMax)
        {
            // 훅이 벽에 닿으면
            if (collision.CompareTag("Wall"))
            {
                joint2D.enabled = true;
                hookShot.isAttach = true;
                hookShot.isAttachWall = true;
            }

            // 훅이 오브젝트에 닿으면
            else if (collision.CompareTag("Object"))
            {
                joint2D.enabled = true;
                hookShot.isAttach = true;
                hookShot.isAttachObject = true;
            }

            // 훅이 몹에 닿으면
            else if (collision.CompareTag("Monster"))
            {
                // 줄 거두기
                hookShot.HookOFF();
                // 해당 몹 죽이기
                collision.gameObject.SetActive(false);
                // or 해당 몹 데미지 주는 함수 호출하기
                // collision.gameObject.GetComponent<MonsterScript>().Damage();
            }

            // 아무것도 해당 안되는 물체에 닿으면
            else
            {
                // 줄 거두기
                hookShot.HookOFF();
            }
        }
    }

}
