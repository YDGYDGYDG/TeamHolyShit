using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public GameObject water1;
    public GameObject water2;
    public GameObject water3;



    float time = 0;
    public float maxtime = 4;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= maxtime)
        {
            time = 0;
            water1.SetActive(true);
            water2.SetActive(true);
            water3.SetActive(true);
        }
    }
}
