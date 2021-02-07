using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int mod = 1;
    float time = 0;
    public int changtime = 3;
    public int HP = 10;

    ObjectRedController rBox;
    ObjectBlueController bBox;
    ObjectGreyController gBox;
    ObjectWhiteController wBox;

    BossSetActiveController modtime;

    int scene;
    
    // Start is called before the first frame update
    void Start()
    {
        rBox = GameObject.Find("RedBoxPos").GetComponent<ObjectRedController>();
        bBox = GameObject.Find("BlueBoxPos").GetComponent<ObjectBlueController>();
        gBox = GameObject.Find("GreyBoxPos").GetComponent<ObjectGreyController>();
        wBox = GameObject.Find("WhiteBoxPos").GetComponent<ObjectWhiteController>();
        mod = 1;
        modtime = GameObject.Find("Boss").GetComponent<BossSetActiveController>();
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
                modtime.time = 0;
                Destroy(collider.gameObject);
                rBox.red = false;
                mod = Random.Range(1, 5);
            }
        }
        if (collider.gameObject.name == "BlueBox(Clone)")
        {
            if (mod == 2)
            {
                HP -= 1;
                modtime.time = 0;
                Destroy(collider.gameObject);
                bBox.blue = false;
                mod = Random.Range(1, 5);
            }
        }
        if (collider.gameObject.name == "WhiteBox(Clone)")
        {
            if (mod == 3)
            {
                HP -= 1;
                modtime.time = 0;
                Destroy(collider.gameObject);
                wBox.white = false;
                mod = Random.Range(1, 5);
            }
        }
        if (collider.gameObject.name == "GreyBox(Clone)")
        {
            if (mod == 4)
            {
                HP -= 1;
                modtime.time = 0;
                Destroy(collider.gameObject);
                gBox.grey = false;
                mod = Random.Range(1, 5);
            }
        }

    }
    void Update()
    {
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
