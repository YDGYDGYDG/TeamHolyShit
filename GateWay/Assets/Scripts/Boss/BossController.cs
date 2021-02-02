using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int mod = 1;
    float time = 0;
    public int changtime = 3;
    public int HP = 10;

    ObjectRedController rBox;
    
    // Start is called before the first frame update
    void Start()
    {
        rBox = GameObject.Find("RedBoxPos").GetComponent<ObjectRedController>();
    }
    void Change()
    {
        time += Time.deltaTime; ;
        if ((int)time > changtime)
        {
            time = 0;
            mod = Random.Range(1, 5);
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "RedBox(Clone)" )
        {
            if (mod == 1)
            {
                HP -= 1;
                Destroy(collider.gameObject);
                rBox.red = false;
            }
        }
        if (collider.gameObject.name == "BlueBox")
        {
            if (mod == 2)
            {
                HP -= 1;
                Destroy(collider.gameObject);
            }
        }
        if (collider.gameObject.name == "WhiteBox")
        {
            if (mod == 3)
            {
                HP -= 1;
                Destroy(collider.gameObject);
            }
        }
        if (collider.gameObject.name == "GreyBox")
        {
            if (mod == 4)
            {
                HP -= 1;
                Destroy(collider.gameObject);
            }
        }

    }
    void Update()
    {
        // 보스 4가지 상태
        Change();
        if (mod == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (mod == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;

        }
        else if (mod == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        else if (mod == 4)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;

        }

        // 사망처리
        if (HP == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
