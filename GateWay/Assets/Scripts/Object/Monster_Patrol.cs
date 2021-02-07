using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Patrol : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    public GameObject monsterDeathEffect;

    void Start()
    {
        desPos = endPos;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos)
            {
                desPos = startPos;
            }
            else
            {
                desPos = endPos;
            }
        }

        if (desPos.position.x - transform.position.x > 0) 
        {
            this.transform.rotation = Quaternion.identity;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hook")      
        {
            Instantiate(monsterDeathEffect, transform.position, Quaternion.identity); 
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            Instantiate(monsterDeathEffect, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }

    }
}
