using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int mod = 1;
    public int HP = 8;

    ObjectRedController rBox;
    ObjectBlueController bBox;
    ObjectGreyController gBox;
    ObjectWhiteController wBox;

    BossSetActiveController modtime;

    // 보스 패턴
    public GameObject red;
    public GameObject blue;
    public GameObject grey;
    public GameObject white;
    public GameObject whiteWall;

    public GameObject cred;
    public GameObject cblue;
    public GameObject cgrey;
    public GameObject cwhite;

    public GameObject bossEffect;

    public float time;

    public float timeMax = 1;

    bool start;


    // Start is called before the first frame update
    void Start()
    {
        rBox = GameObject.Find("RedBoxPos").GetComponent<ObjectRedController>();
        bBox = GameObject.Find("BlueBoxPos").GetComponent<ObjectBlueController>();
        gBox = GameObject.Find("GreyBoxPos").GetComponent<ObjectGreyController>();
        wBox = GameObject.Find("WhiteBoxPos").GetComponent<ObjectWhiteController>();
        mod = Random.Range(1,5);

        red.SetActive(false);
        blue.SetActive(false);
        grey.SetActive(false);
        white.SetActive(false);
        cred.SetActive(false);
        cblue.SetActive(false);
        cgrey.SetActive(false);
        cwhite.SetActive(false);
    }



    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "RedBox(Clone)" )
        {
            if (mod == 1)
            {
                HP -= 1;
                Instantiate(bossEffect, collider.transform.position, Quaternion.identity);  // 이펙트도 출력해
                start = true;
                time = 0;
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
                Instantiate(bossEffect, collider.transform.position, Quaternion.identity);  // 이펙트도 출력해
                start = true;
                time = 0;
                Destroy(collider.gameObject);
                bBox.blue = false;
                mod = Random.Range(1, 5);
            }
        }
        if (collider.gameObject.name == "GreyBox(Clone)")
        {
            if (mod == 3)
            {
                HP -= 1;
                Instantiate(bossEffect, collider.transform.position, Quaternion.identity);  // 이펙트도 출력해
                start = true;
                time = 0;
                Destroy(collider.gameObject);
                gBox.grey = false;
                mod = Random.Range(1, 5);
            }
        }
        if (collider.gameObject.name == "WhiteBox(Clone)")
        {
            if (mod == 4)
            {
                HP -= 1;
                Instantiate(bossEffect, collider.transform.position, Quaternion.identity);  // 이펙트도 출력해
                start = true;
                time = 0;
                Destroy(collider.gameObject);
                wBox.white = false;
                mod = Random.Range(1, 5);
            }
        }

    }
    void Update()
    {
        if (start)
        {
            if (mod == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                time += Time.deltaTime;
                if (time < timeMax)
                {
                    red.SetActive(false);
                    blue.SetActive(false);
                    grey.SetActive(false);
                    white.SetActive(false);
                    whiteWall.SetActive(true);
                    cred.SetActive(true);
                    cblue.SetActive(false);
                    cgrey.SetActive(false);
                    cwhite.SetActive(false);
                }
                else
                {
                    red.SetActive(true);

                }
            }
            else if (mod == 2)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                time += Time.deltaTime;
                if (time < timeMax)
                {
                    red.SetActive(false);
                    blue.SetActive(false);
                    grey.SetActive(false);
                    white.SetActive(false);
                    whiteWall.SetActive(true);
                    cred.SetActive(false);
                    cblue.SetActive(true);
                    cgrey.SetActive(false);
                    cwhite.SetActive(false);
                }
                else
                {
                    blue.SetActive(true);

                }
            }
            else if (mod == 3)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.grey;
                time += Time.deltaTime;
                if (time < timeMax)
                {
                    red.SetActive(false);
                    blue.SetActive(false);
                    grey.SetActive(false);
                    white.SetActive(false);
                    whiteWall.SetActive(true);
                    cred.SetActive(false);
                    cblue.SetActive(false);
                    cgrey.SetActive(true);
                    cwhite.SetActive(false);
                }
                else
                {
                    grey.SetActive(true);

                }
            }
            else if (mod == 4)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                time += Time.deltaTime;
                if (time < timeMax)
                {
                    red.SetActive(false);
                    blue.SetActive(false);
                    grey.SetActive(false);
                    white.SetActive(false);
                    whiteWall.SetActive(true);
                    cred.SetActive(false);
                    cblue.SetActive(false);
                    cgrey.SetActive(false);
                    cwhite.SetActive(true);
                }
                else
                {
                    white.SetActive(true);
                    whiteWall.SetActive(false);
                }
            }
        }
        else if (!start)
        {
            if (mod == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                cred.SetActive(true);
            }
            else if (mod == 2)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                cblue.SetActive(true);
            }
            else if (mod == 3)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.grey;
                cgrey.SetActive(true);
            }
            else if (mod == 4)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                cwhite.SetActive(true);
            }
        }


        // 사망처리
        if (HP == 0)
        {
            time += Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            red.SetActive(false);
            blue.SetActive(false);
            grey.SetActive(false);
            white.SetActive(false);
            whiteWall.SetActive(true);
            cred.SetActive(false);
            cblue.SetActive(false);
            cgrey.SetActive(false);
            cwhite.SetActive(false);
            if (time > 5)
            {
                SceneManager.LoadScene("EndingScene");
            }

        }
    }
}
