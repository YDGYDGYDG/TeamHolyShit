using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{

    HookShotScript hookLine;    // 훅 연결용 변수

    public GameObject monsterDeath;

    GameObject box;             // 박스 연결

    Rigidbody2D boxRigibody2D;  // 박스 물리 연결

    // Start is called before the first frame update
    void Start()
    {

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 스크립트 연결
        box = GameObject.FindGameObjectWithTag("Object");   // 박스 태그를 찾고
        box.layer = LayerMask.NameToLayer("shootable");     // 레이어 이름 값을 찾아
        boxRigibody2D = box.GetComponent<Rigidbody2D>();     // 박스 리지드 연결하고?

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Hook")        // 너 밧줄이랑 충돌했니??
        {

            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
            hookLine.HookOFF();                 // 훅도 지워줘야지??

        }

        else if (boxRigibody2D.velocity.y > 0 && col.gameObject)       
        {

            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
           
            

        }
    }


    

    

}

    
