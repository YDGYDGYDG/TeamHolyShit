using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public GameObject water1;
    public GameObject water2;
    public GameObject water3;
    public GameObject water4;
    public GameObject water5;
    public GameObject water6;
    public GameObject water7;
    public GameObject water8;
    public GameObject water9;
    public GameObject water10;
    public GameObject water11;
    public GameObject water12;
    public GameObject water13;



    float time = 0;
    public float starttime = 0.5f;
    public float maxtime = 1.5f;
    float changetime;
    public float addtime = 1;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= starttime)
        {
            changetime = maxtime + addtime;
            water13.SetActive(true);
            if(time >= changetime)
            {
                time = 0;
            }
            if (time < maxtime)
            {
                water1.SetActive(false);
                water2.SetActive(false);
                water3.SetActive(false);
                water4.SetActive(false);
                water5.SetActive(false);
                water6.SetActive(false);
                water7.SetActive(false);
                water8.SetActive(false);
                water9.SetActive(false);
                water10.SetActive(false);
                water11.SetActive(false);
                water12.SetActive(false);
                water13.SetActive(false);
            }
            else if (time >= maxtime)
            {
                water1.SetActive(true);
                water2.SetActive(true);
                water3.SetActive(true);
                water4.SetActive(true);
                water5.SetActive(true);
                water6.SetActive(true);
                water7.SetActive(true);
                water8.SetActive(true);
                water9.SetActive(true);
                water10.SetActive(true);
                water11.SetActive(true);
                water12.SetActive(true);
            }

        }


    }
}
