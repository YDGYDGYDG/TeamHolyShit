using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPortraitMonsterGenerater : MonoBehaviour
{
    GameObject player;
    public GameObject rangeLeft;
    public GameObject rangeRight;

    public float monsterSpeed;

    public GameObject waterMonsterPrefab;
    public float span = 3f;
    float delta = 0;



    void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            float ran = Random.Range(rangeLeft.transform.position.y, rangeRight.transform.position.y);
            GameObject waterMonster = Instantiate(waterMonsterPrefab) as GameObject;
            waterMonster.transform.position = new Vector2(rangeLeft.transform.position.x, ran);
        }
    }
}
