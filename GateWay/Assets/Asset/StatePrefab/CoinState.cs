using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinState : MonoBehaviour
{

    public GameObject CoinEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")        // 너 플레이어랑 충돌했니??
        {

            this.gameObject.SetActive(false);   // 그럼 없어져
            
            

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
