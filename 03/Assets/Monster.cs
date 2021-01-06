using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    int hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 20)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void Damage()
    {
        hp -= 20;
    }
}
