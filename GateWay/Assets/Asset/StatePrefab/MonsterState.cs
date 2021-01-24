using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{
    

    public GameObject monsterDeath;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Hook")        // 너 밧줄이랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            Instantiate(monsterDeath, transform.position, Quaternion.identity);  // 이펙트도 출력해
            
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {



    }

    

}

    
