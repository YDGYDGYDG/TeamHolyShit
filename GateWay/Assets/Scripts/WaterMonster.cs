using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonster : MonoBehaviour
{
    public int monsterSpeed = 100;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, monsterSpeed));
        
    }
}
