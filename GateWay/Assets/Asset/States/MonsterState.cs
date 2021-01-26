using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{

    HookShotScript hookLine;    // 훅 연결용 변수

    public GameObject monsterDeath;

    // Start is called before the first frame update
    void Start()
    {

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 스크립트 연결

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Hook")        // 너 밧줄이랑 충돌했니??
        {

            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
            hookLine.HookOFF();                 // 훅도 지워줘야지??

        }
    }


    

    

}

    
