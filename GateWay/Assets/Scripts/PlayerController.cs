using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

     

    // Start is called before the first frame update
    void Start()
    {
        
        

        
    }
    // 캐릭터가 죽음
    public void PlayerDead()
    {
        Debug.Log("캐릭터 사망");
        this.gameObject.SetActive(false);

        

        //this.gameObject.SetActive(false);                       // 플레이어를 없앤다(형준)
        //deathEffect.GetComponent<ParticleSystem>().Play();      // 사망 이펙트를 실행(형준)
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
