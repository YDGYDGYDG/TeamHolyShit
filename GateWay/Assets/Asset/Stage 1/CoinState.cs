using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.tag == "Star")
        {
            if(col.gameObject.tag == "Player")
            {
                this.gameObject.SetActive(false);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
