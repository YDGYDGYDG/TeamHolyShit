using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState : MonoBehaviour
{

    HookShotScript hookLine;    // 훅 연결용 변수

    public GameObject playerDeath;  // 플레이어 죽었을 때

    public GameObject takeCoin;     // 코인 획득했을 때
    GameObject Coin;                // 코인 연결용

    GameObject Door;                       // 문 연결
    CapsuleCollider2D openDoor;            // 문 열어라~

    

    // Start is called before the first frame update
    void Start()
    {
        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 훅샷 스크립트 연결
        Coin = GameObject.Find("Coin");     // 코인 연결
        Door = GameObject.Find("Door");     // 문 연결
        openDoor = Door.GetComponent<CapsuleCollider2D>();  // 트리거 연결
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")        // 너 몬스터랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            Instantiate(playerDeath, transform.position, Quaternion.identity);    // 이펙트도 출력해
        }

        else if (col.gameObject.tag == "Trap")        // 너 함정이랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            Instantiate(playerDeath, transform.position, Quaternion.identity);    // 이펙트도 출력해
        }

        else if (col.gameObject.tag == "Star")     // 너 동전이랑 충돌했니??
        {
            Coin.SetActive(false);                 // 동전 지워줘
            Instantiate(takeCoin, transform.position, Quaternion.identity);    // 이펙트도 출력해
            openDoor.enabled = true;               // 문 열어~~~
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
