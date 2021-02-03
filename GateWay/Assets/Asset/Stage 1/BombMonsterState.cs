using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMonsterState : MonoBehaviour
{
    BombMonster bombScript;
    GameObject bombMonster2;
    HookShotScript hookLine2;

    public GameObject bomb;

    GameObject box;             
    Rigidbody2D boxRigid;       

    // Start is called before the first frame update
    void Start()
    {
        hookLine2 = GameObject.Find("player").GetComponent<HookShotScript>();

        box = GameObject.FindGameObjectWithTag("Object");
        boxRigid = box.GetComponent<Rigidbody2D>();

        bombMonster2 = GameObject.Find("BombMonster");
        bombScript = bombMonster2.GetComponent<BombMonster>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.tag == "BombMonster")
        {
            if (col.gameObject.tag == "Hook")        // 너 밧줄이랑 충돌했니??
            {
                Destroy(bombMonster2);
                Instantiate(bomb, transform.position, Quaternion.identity);  // 이펙트도 출력해
                hookLine2.HookOFF();                 // 훅도 지워줘야지??
            }

            else if (col.gameObject.tag == "Object")
            {
                // 박스 속도가 0이 아닐때만 죽여
                if (boxRigid.velocity.x != 0 || boxRigid.velocity.y != 0)
                {
                    Destroy(bombMonster2);
                    Instantiate(bomb, transform.position, Quaternion.identity);  // 이펙트도 출력해
                    Destroy(box);       // 충돌한 박스는 없애
                }
            }

            else if (col.gameObject.tag == "Player")        // 너 플레이어랑 충돌?
            {
                Destroy(bombMonster2);  // 자폭 ㄱㄱㄱㄱ
                Instantiate(bomb, transform.position, Quaternion.identity);  // 이펙트도 출력해
                hookLine2.HookOFF();                 // 훅도 지워줘야지??
            }
        }
    }

    
}
