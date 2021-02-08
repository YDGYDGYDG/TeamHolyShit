using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingController : MonoBehaviour
{
    SpriteRenderer ending1;
    SpriteRenderer ending2;
    SpriteRenderer ending3;
    SpriteRenderer ending4;

    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public GameObject e4;

    bool endtrigger1;
    bool endtrigger2;
    bool endtrigger3;
    bool endtrigger4;

    float time;



    // Start is called before the first frame update
    void Start()
    {
        ending1 = e1.GetComponent<SpriteRenderer>();
        Color ea1 = ending1.material.color;
        ea1.a = 0;
        ending1.material.color = ea1;

        ending2 = e2.GetComponent<SpriteRenderer>();
        Color ea2 = ending2.material.color;
        ea2.a = 0;
        ending2.material.color = ea2;

        ending3 = e3.GetComponent<SpriteRenderer>();
        Color ea3 = ending3.material.color;
        ea3.a = 0;
        ending3.material.color = ea3;

        ending4 = e4.GetComponent<SpriteRenderer>();
        Color ea4 = ending4.material.color;
        ea4.a = 0;
        ending4.material.color = ea4;


    }

    IEnumerator EndingScene()
    {
        if (!endtrigger1 && !endtrigger2 && !endtrigger3 && !endtrigger4)
        {
            for (int i = 0; i < 10; i++)
            {
                float f = i / 10.0f;
                Color c1 = ending1.material.color;
                c1.a = f;
                ending1.material.color = c1;
                endtrigger1 = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (endtrigger1 && !endtrigger2 && !endtrigger3 && !endtrigger4)
        {
            for (int i = 0; i < 10; i++)
            {
                float f = i / 10.0f;
                Color c2 = ending2.material.color;
                c2.a = f;
                ending2.material.color = c2;
                endtrigger2 = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (endtrigger1 && endtrigger2 && !endtrigger3 && !endtrigger4)
        {
            for (int i = 0; i < 10; i++)
            {
                float f = i / 10.0f;
                Color c3 = ending3.material.color;
                c3.a = f;
                ending3.material.color = c3;
                endtrigger3 = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (endtrigger1 && endtrigger2 && endtrigger3 && !endtrigger4)
        {
            for (int i = 0; i < 10; i++)
            {
                float f = i / 10.0f;
                Color c4 = ending4.material.color;
                c4.a = f;
                ending4.material.color = c4;
                endtrigger4 = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (endtrigger1 && endtrigger2 && endtrigger3 && endtrigger4)
        {
            SceneManager.LoadScene("MainScene");
        }


    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time > 5)
        {
            StartCoroutine("EndingScene");
            time = 0;
        }
    }
    public void ButtonON()
    {
        if (time > 2)
        {
            StartCoroutine("EndingScene");
            time = 0;
        }

    }
}
