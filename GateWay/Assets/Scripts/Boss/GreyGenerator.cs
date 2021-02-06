using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGenerator : MonoBehaviour
{
    float time;  // 경과 시간
    public float BTime = 0.5f;
    public float RTime = 0.6f;
    public float DTime = 2f;

    public GameObject rlur;
    public GameObject rlub;
    public GameObject rldr;
    public GameObject rldb;
    public GameObject udlr;
    public GameObject udlb;
    public GameObject udrr;
    public GameObject udrb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 5);
        Rayoff();

    }
    
    void RLUR()
    {
        rlur.SetActive(true);
        rlub.SetActive(false);
    }
    void RLUB()
    {
        rlub.SetActive(true);
        rlur.SetActive(false);
    }

    void RLDR()
    {
        rldr.SetActive(true);
        rlub.SetActive(false);
    }
    void RLDB()
    {
        rldb.SetActive(true);
        rldr.SetActive(false);
    }

    void UDRR()
    {
        udrr.SetActive(true);
        udrb.SetActive(false);
    }
    void UDRB()
    {
        udrb.SetActive(true);
        udrr.SetActive(false);
    }

    void UDLR()
    {
        udlr.SetActive(true);
        udlb.SetActive(false);
    }
    void UDLB()
    {
        udlb.SetActive(true);
        udlr.SetActive(false);
    }

    void Rayoff()
    {
        rlur.SetActive(false);
        rlub.SetActive(false);
        rldr.SetActive(false);
        rldb.SetActive(false);
        udlr.SetActive(false);
        udlb.SetActive(false);
        udrr.SetActive(false);
        udrb.SetActive(false);
    }

    int random;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (random == 1)
        {
            if (time < BTime)
            {
                RLUB();
                UDRB();
            }
            else if (time < RTime)
            {
                RLUR();
                UDRR();
            }
            else
            {
                Rayoff();
            }
        }
        if (random == 2)
        {
            if (time < BTime)
            {
                RLUB();
                UDLB();
            }
            else if (time < RTime)
            {
                RLUR();
                UDLR();
            }
            else
            {
                Rayoff();
            }
        }
        if ( random == 3)
        {
            if (time < BTime)
            {
                RLDB();
                UDRB();
            }
            else if (time < RTime)
            {
                RLDR();
                UDRR();
            }
            else
            {
                Rayoff();
            }
        }
        if (random == 4)
        {
            if (time < BTime)
            {
                RLDB();
                UDLB();
            }
            else if (time < RTime)
            {
                RLDR();
                UDLR();
            }
            else
            {
                Rayoff();
            }
        }
        if (time > DTime)
        {
            time = 0;
            random = Random.Range(1, 5);
        }
    }
}
