using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwallController : MonoBehaviour
{
    float time;  // 경과 시간
    float WallReset; // 벽 초기화
    public float ATime = 1.0f;
    public float BTime = 1.0f;
    public GameObject [] Awall;
    public GameObject [] Bwall;


    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<Awall.Length; i++)
        {
            Awall[i].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        }
        for (int i = 0; i < Bwall.Length; i++)
        {
            Bwall[i].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        }
    }

    void AWalls()
    {
        for (int i = 0; i < Awall.Length; i++)
        {
            Awall[i].GetComponent<SpriteRenderer>().material.color = Color.white;
            Awall[i].GetComponent<BoxCollider2D>().isTrigger = false;
            Awall[i].gameObject.tag = "Wall";
        }
        for (int i = 0; i < Bwall.Length; i++)
        {
            Bwall[i].GetComponent<SpriteRenderer>().material.color = Color.clear;
            Bwall[i].GetComponent<BoxCollider2D>().isTrigger = true;
            Bwall[i].gameObject.tag = "Untagged";
        }
    }
    void BWalls()
    {
        for (int i = 0; i < Bwall.Length; i++)
        {
            Bwall[i].GetComponent<SpriteRenderer>().material.color = Color.white;
            Bwall[i].GetComponent<BoxCollider2D>().isTrigger = false;
            Bwall[i].gameObject.tag = "Wall";
        }
        for (int i = 0; i < Awall.Length; i++)
        {
            Awall[i].GetComponent<SpriteRenderer>().material.color = Color.clear;
            Awall[i].GetComponent<BoxCollider2D>().isTrigger = true;
            Awall[i].gameObject.tag = "Untagged";
        }

    }
    void Update()
    {
        WallReset = BTime + ATime;

        time += Time.deltaTime;
        if (time < ATime)
            AWalls();
        if (time >= BTime)
            BWalls();

        if (time > WallReset)
            time = 0;
    }
}