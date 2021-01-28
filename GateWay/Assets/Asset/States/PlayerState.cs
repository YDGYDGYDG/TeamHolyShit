using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState : MonoBehaviour
{
    GameObject hookDisWall;
    HookShotScript hookLine;    // 훅 연결용 변수
    Air air;

    public GameObject playerDeath;  // 플레이어 죽었을 때

    public GameObject takeCoin;     // 코인 획득했을 때
    GameObject Coin;                // 코인 연결용

    GameObject Door;                       // 문 연결
    CapsuleCollider2D openDoor;            // 문 열어라~

    // 캐릭터 부활 위치(맵에 따라 다름 인스펙터에서 조절하세요~~)
    public Vector2 playerStartPosition = new Vector2(0f, 0f);

    
    public void playerRevive()     // 부활 함수
    {
        this.gameObject.SetActive(true);            // 플레이어 다시 켜주고
        transform.position = playerStartPosition;   // 시작 위치로 이동 시켜
        ResetPos();
    }
    private void ResetPos()
    {
        hookDisWall.SetActive(true);
        air.curAir = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 훅샷 스크립트 연결
        Coin = GameObject.Find("Coin");     // 코인 연결
        Door = GameObject.Find("Door");     // 문 연결
        openDoor = Door.GetComponent<CapsuleCollider2D>();  // 트리거 연결
        playerStartPosition = gameObject.transform.position;
        hookDisWall = GameObject.Find("HookDisWall");
        air = GameObject.Find("player").GetComponent<Air>();



    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")        // 너 몬스터랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            // 이펙트도 출력해
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "Trap")        // 너 함정이랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            // 이펙트도 출력해
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "Star")     // 너 동전이랑 충돌했니??
        {
            Coin.SetActive(false);                 // 동전 지워줘
            // 이펙트도 출력해
            Instantiate(takeCoin, transform.position, Quaternion.identity);    
            openDoor.enabled = true;               // 문 열어~~~
           
        }

    }

   


    // Update is called once per frame
    void Update()
    {
        
    }



}
