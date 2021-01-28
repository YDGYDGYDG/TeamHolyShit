using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public GameObject takeCoin;     // 코인 획득했을 때
    GameObject Coin;                // 코인 연결용

    GameObject Door;                       // 문 연결
    CapsuleCollider2D openDoor;            // 문 열어라~

    // Start is called before the first frame update
    void Start()
    {
        Coin = GameObject.Find("Coin");     // 코인 연결
        Door = GameObject.Find("Door");     // 문 연결
        openDoor = Door.GetComponent<CapsuleCollider2D>();  // 트리거 연결
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Star")     // 너 동전이랑 충돌했니??
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
