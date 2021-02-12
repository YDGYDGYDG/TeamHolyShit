using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonsterRLGenerator : MonoBehaviour
{
    public GameObject range;
    public GameObject waterMonsterPrefab;
    public float span = 5f;
    float delta = 0;



    void Start()
    {
        GameObject waterMonster = Instantiate(waterMonsterPrefab) as GameObject;
        waterMonster.transform.position = new Vector2(range.transform.position.x, range.transform.position.y);
        waterMonster.transform.parent = gameObject.transform;
    }

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject waterMonster = Instantiate(waterMonsterPrefab) as GameObject;
            waterMonster.transform.position = new Vector2(range.transform.position.x, range.transform.position.y);
            waterMonster.transform.parent = gameObject.transform;
        }

    }
}