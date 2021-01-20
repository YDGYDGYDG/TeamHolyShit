using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    GameObject player;

    HookShotScript hookShot;
    DistanceJoint2D joint2D;
    DistanceJoint2D playerJoint2D;

    float lineSpeed;

    void Start()
    {
        player = GameObject.Find("player");
        hookShot = player.GetComponent<HookShotScript>();
        lineSpeed = hookShot.lineSpeed;
        joint2D = GetComponent<DistanceJoint2D>();
        playerJoint2D = player.GetComponent<DistanceJoint2D>();
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
                playerJoint2D.enabled = true;

                // 플레이어가 가진 joint 길이 줄이기
                if (playerJoint2D.distance > 1)
                {
                    Debug.Log("작동해야할텐데?");
                    playerJoint2D.distance -= Time.deltaTime * lineSpeed;
                }

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

            // ~ 물체에 닿으면
            //else if (collision.CompareTag(""))
            //{
            //    // 줄 거두기
            //    hookShot.HookOFF();
            //}
        }
    }

}
