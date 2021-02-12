using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGenerator : MonoBehaviour
{
    float time;  // 경과 시간
    public float BTime = 0.5f;
    public float RTime = 0.6f;
    public float DTime = 2f;

    public GameObject upRadRay;
    public GameObject upBlueRay;
    public GameObject downRadRay;
    public GameObject downBlueRay;
    public GameObject laftRadRay;
    public GameObject laftBlueRay;
    public GameObject righteRadRay;
    public GameObject rightBlueRay;


    // Start is called before the first frame update
    void Start()
    {
        // random = Random.Range(1, 13);
        Rayoff();

    }
    
    void RadRay()
    {
        upRadRay.SetActive(true);
        downRadRay.SetActive(true);
        laftRadRay.SetActive(true);
        righteRadRay.SetActive(true);

        upBlueRay.SetActive(false);
        downBlueRay.SetActive(false);
        laftBlueRay.SetActive(false);
        rightBlueRay.SetActive(false);
    }
    void BlueRay()
    {
        upRadRay.SetActive(false);
        downRadRay.SetActive(false);
        laftRadRay.SetActive(false);
        righteRadRay.SetActive(false);

        upBlueRay.SetActive(true);
        downBlueRay.SetActive(true);
        laftBlueRay.SetActive(true);
        rightBlueRay.SetActive(true);
    }
 

    void Rayoff()
    {
        upRadRay.SetActive(false);
        upBlueRay.SetActive(false);
        downRadRay.SetActive(false);
        downBlueRay.SetActive(false);
        laftRadRay.SetActive(false);
        laftBlueRay.SetActive(false);
        righteRadRay.SetActive(false);
        rightBlueRay.SetActive(false);
    }

    int random;

    float pos = 100;
    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.deltaTime;
        // if (random == 1)
        // {
        //     pos = 75;
        // }
        // else if (random == 2)
        // {
        //     pos = 70;
        // }
        // else if (random == 3)
        // {
        //     pos = 31.2f;
        // }
        // else if (random == 4)
        // {
        //     pos = 15;
        // }
        // else if (random == 5)
        // {
        //     pos = 6;
        // }
        // else if (random == 6)
        // {
        //     pos = 4.6f;
        // }
        // else if (random == 7)
        // {
        //     pos = 97.2f;
        // }
        // else if (random == 8)
        // {
        //     pos = 105;
        // }
        // else if (random == 9)
        // {
        //     pos = 105;
        // }
        // else if (random == 10)
        // {
        //     pos = 112.4f;
        // }
        // else if (random == 11)
        // {
        //     pos = 121.4f;
        // }
        // else if (random == 12)
        // {
        //     pos = 145.1f;
        // }



        if (time < BTime)
        {
            gameObject.transform.Rotate(0, 0, 0);
            BlueRay();
        }
        else if (time < RTime)
        {
            gameObject.transform.Rotate(0, 0, 0);
            RadRay();
        }
        else
        {
            gameObject.transform.Rotate(0, 0, 5);
            Rayoff();
        }





        if (time > DTime)
        {
            time = 0;
            // random = Random.Range(1, 13);
        }
    }
}
