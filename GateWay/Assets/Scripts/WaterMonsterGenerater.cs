using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonsterGenerater : MonoBehaviour
{
    GameObject player;
    public GameObject rangeLeft;
    public GameObject rangeRight;


    public GameObject waterMonsterPrefab;
    public float span = 3f;
    float delta = 0;



    void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        if (player.transform.position.x > rangeLeft.transform.position.x && player.transform.position.x < rangeRight.transform.position.x)
        {
            delta += Time.deltaTime;
            if (delta > span)
            {
                delta = 0;
                GameObject waterMonster = Instantiate(waterMonsterPrefab) as GameObject;
                waterMonster.transform.position = new Vector2(player.transform.position.x, rangeLeft.transform.position.y);
            }
        }
    }
}
