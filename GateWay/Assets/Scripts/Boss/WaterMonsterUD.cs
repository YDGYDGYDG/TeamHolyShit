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

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, monsterSpeed));
        if (transform.position.y > 45)
        {
            Destroy(gameObject);
        }

    }
}
