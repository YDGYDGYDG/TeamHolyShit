using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPortraitMonsterGenerater : MonoBehaviour
{
    GameObject player;
    public GameObject rangeLeft;
    public GameObject rangeRight;

    public GameObject waterMonsterPrefab;
    public float monsterSpeed;
    public float span = 1.5f;
    float delta = 0;



    void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        delta += Time.deltaTime;
        if (player.transform.position.y >= rangeLeft.transform.position.y && player.transform.position.y <= rangeRight.transform.position.y)
        {
            if (delta > span)
            {
                delta = 0;
                GameObject waterMonster = Instantiate(waterMonsterPrefab) as GameObject;
                waterMonster.transform.position = new Vector2(rangeLeft.transform.position.x, player.transform.position.y);
            }
        }
    }
}
