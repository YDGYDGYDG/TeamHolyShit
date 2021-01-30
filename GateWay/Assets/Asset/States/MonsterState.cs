using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{

     HookShotScript hookLine;    // 훅 연결용 변수
    

    public GameObject monsterDeath;

    GameObject box;             // 박스 연결
    Rigidbody2D boxRigid;       // 박스 물리


    // Start is called before the first frame update
    void Start()
    {

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 스크립트 연결
       

        box = GameObject.FindGameObjectWithTag("Object");   // 박스 태그를 찾고
        boxRigid = box.GetComponent<Rigidbody2D>();                    // 물리 연결

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.tag == "Monster")
        {
            if (col.gameObject.tag == "Hook")        // 너 밧줄이랑 충돌했니??
            {
                this.gameObject.SetActive(false);   // 그럼 뒤지삼
                Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
                hookLine.HookOFF();                 // 훅도 지워줘야지??
            }

            else if (col.gameObject.tag == "Object")
            {
                // 박스 속도가 0이 아닐때만 죽여
                if (boxRigid.velocity.x != 0 || boxRigid.velocity.y != 0)
                {
                    this.gameObject.SetActive(false);   // 그럼 뒤지삼
                    Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
                    Destroy(box);       // 충돌한 박스는 없애
                }
            }
        }


        else if(this.gameObject.tag == "Boss")
        {
            if (col.gameObject.tag == "Object")
            {
                // 박스 속도가 0이 아닐때만 죽여
                if (boxRigid.velocity.x != 0 || boxRigid.velocity.y != 0)
                {
                    this.gameObject.SetActive(false);   // 그럼 뒤지삼
                    Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
                    Destroy(box);       // 충돌한 박스는 없애
                }
            }

            else if (col.gameObject.tag == "Hook")
            {
                hookLine.HookOFF();     // 훅만 지워
            }
        }
    }


    

    

}

    
