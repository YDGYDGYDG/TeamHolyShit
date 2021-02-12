using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonsterUD : MonoBehaviour
{
    public int monsterSpeed = 100;




    // Start is called before the first frame update
    void Start()
    {
        
    }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     Destroy(gameObject);
    // }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(monsterSpeed,0));
        if (gameObject.transform.position.x >= 20)
        {
            Destroy(gameObject);
        }

    }
}
