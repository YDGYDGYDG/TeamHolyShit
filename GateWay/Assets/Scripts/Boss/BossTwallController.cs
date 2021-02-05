using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwallController : MonoBehaviour
{
    float time;  // 경과 시간
    float WallReset; // 벽 초기화
    public float ATime = 1.0f;
    public float BTime = 1.0f;
    public GameObject Awall1;
    public GameObject Awall2;
    public GameObject Awall3;
    public GameObject Awall4;
    public GameObject Awall5;
    public GameObject Awall6;
    public GameObject Awall7;
    public GameObject Awall8;
    public GameObject Awall9;
    public GameObject Awall10;
    public GameObject Bwall1;
    public GameObject Bwall2;
    public GameObject Bwall3;
    public GameObject Bwall4;
    public GameObject Bwall5;
    public GameObject Bwall6;
    public GameObject Bwall7;
    public GameObject Bwall8;
    public GameObject Bwall9;
    public GameObject Bwall10;


    // Start is called before the first frame update
    void Start()
    {
        Awall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);

    }

    void AWalls()
    {
        Awall1.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall1.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall1.gameObject.tag = "Wall";
        Awall2.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall2.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall2.gameObject.tag = "Wall";
        Awall3.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall3.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall3.gameObject.tag = "Wall";
        Awall4.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall4.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall4.gameObject.tag = "Wall";
        Awall5.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall5.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall5.gameObject.tag = "Wall";
        Awall6.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall6.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall6.gameObject.tag = "Wall";
        Awall7.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall7.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall7.gameObject.tag = "Wall";
        Awall8.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall8.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall8.gameObject.tag = "Wall";
        Awall9.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall9.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall9.gameObject.tag = "Wall";
        Awall10.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall10.GetComponent<BoxCollider2D>().isTrigger = false;
        Awall10.gameObject.tag = "Wall";
        Bwall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall1.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall1.gameObject.tag = "Untagged";
        Bwall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall2.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall2.gameObject.tag = "Untagged";
        Bwall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall3.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall3.gameObject.tag = "Untagged";
        Bwall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall4.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall4.gameObject.tag = "Untagged";
        Bwall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall5.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall5.gameObject.tag = "Untagged";
        Bwall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall6.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall6.gameObject.tag = "Untagged";
        Bwall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall7.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall7.gameObject.tag = "Untagged";
        Bwall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall8.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall8.gameObject.tag = "Untagged";
        Bwall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall9.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall9.gameObject.tag = "Untagged";
        Bwall10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall10.GetComponent<BoxCollider2D>().isTrigger = true;
        Bwall10.gameObject.tag = "Untagged";
    }
    void BWalls()
    {
        Bwall1.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall1.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall1.gameObject.tag = "Wall";
        Bwall2.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall2.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall2.gameObject.tag = "Wall";
        Bwall3.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall3.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall3.gameObject.tag = "Wall";
        Bwall4.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall4.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall4.gameObject.tag = "Wall";
        Bwall5.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall5.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall5.gameObject.tag = "Wall";
        Bwall6.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall6.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall6.gameObject.tag = "Wall";
        Bwall7.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall7.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall7.gameObject.tag = "Wall";
        Bwall8.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall8.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall8.gameObject.tag = "Wall";
        Bwall9.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall9.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall9.gameObject.tag = "Wall";
        Bwall10.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall10.GetComponent<BoxCollider2D>().isTrigger = false;
        Bwall10.gameObject.tag = "Wall";
        Awall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall1.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall1.gameObject.tag = "Untagged";
        Awall2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall2.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall2.gameObject.tag = "Untagged";
        Awall3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall3.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall3.gameObject.tag = "Untagged";
        Awall4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall4.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall4.gameObject.tag = "Untagged";
        Awall5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall5.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall5.gameObject.tag = "Untagged";
        Awall6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall6.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall6.gameObject.tag = "Untagged";
        Awall7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall7.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall7.gameObject.tag = "Untagged";
        Awall8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall8.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall8.gameObject.tag = "Untagged";
        Awall9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall9.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall9.gameObject.tag = "Untagged";
        Awall10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall10.GetComponent<BoxCollider2D>().isTrigger = true;
        Awall10.gameObject.tag = "Untagged";
    }
    // Update is called once per frame
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