using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

     GameObject deathEffect;     // 사망 이펙트 재생용(형준)
     GameObject outChartter;      // 

    // Start is called before the first frame update
    void Start()
    {
        deathEffect = GameObject.Find("Death");     // 사망 프리팹 연결(형준)
        

        
    }
    // 캐릭터가 죽음
    public void PlayerDead()
    {
        Debug.Log("캐릭터 사망");


        

        //this.gameObject.SetActive(false);                       // 플레이어를 없앤다(형준)
        //deathEffect.GetComponent<ParticleSystem>().Play();      // 사망 이펙트를 실행(형준)
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
