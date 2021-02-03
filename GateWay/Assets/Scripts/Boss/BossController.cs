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

    int scene;
    
    // Start is called before the first frame update
    void Start()
    {
        rBox = GameObject.Find("RedBoxPos").GetComponent<ObjectRedController>();
        bBox = GameObject.Find("BlueBoxPos").GetComponent<ObjectBlueController>();
        gBox = GameObject.Find("GreyBoxPos").GetComponent<ObjectGreyController>();
        wBox = GameObject.Find("WhiteBoxPos").GetComponent<ObjectWhiteController>();
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

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
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
                scene = Random.Range(1, 4);
                Debug.Log(scene);
                if (scene == 1)
                {
                    SceneManager.LoadScene("TestSceneBlue");
                    Debug.Log("a");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneGrey");
                    Debug.Log("b");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneWhite");
                    Debug.Log("c");
                }
                
            }
        }
        if (collider.gameObject.name == "BlueBox(Clone)")
        {
            if (mod == 2)
            {
                HP -= 1;
                Destroy(collider.gameObject);
                bBox.blue = false;
                scene = Random.Range(1, 4);
                if (scene == 1)
                {
                    SceneManager.LoadScene("TestSceneRed");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneGrey");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneWhite");
                }
            }
        }
        if (collider.gameObject.name == "WhiteBox(Clone)")
        {
            if (mod == 3)
            {
                HP -= 1;
                Destroy(collider.gameObject);
                wBox.white = false;
                scene = Random.Range(1, 4);
                if (scene == 1)
                {
                    SceneManager.LoadScene("TestSceneRed");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneBlue");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneGrey");
                }
            }
        }
        if (collider.gameObject.name == "GreyBox(Clone)")
        {
            if (mod == 4)
            {
                HP -= 1;
                Destroy(collider.gameObject);
                gBox.grey = false;
                scene = Random.Range(1, 4);
                if (scene == 1)
                {
                    SceneManager.LoadScene("TestSceneRed");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneBlue");
                }
                else if (scene == 2)
                {
                    SceneManager.LoadScene("TestSceneWhite");
                }
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
