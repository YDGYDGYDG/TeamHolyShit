using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRPortraitMonster : MonoBehaviour
{
    public float monsterSpeed = 100;
    public WaterPortraitMonsterGenerater waterPor;

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
        waterPor = GameObject.Find("WaterRMonsterGenerator").GetComponent<WaterPortraitMonsterGenerater>();
    }

    // Update is called once per frame
    void Update()
    {

        monsterSpeed = waterPor.monsterSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(monsterSpeed, 0));
        
    }
}
