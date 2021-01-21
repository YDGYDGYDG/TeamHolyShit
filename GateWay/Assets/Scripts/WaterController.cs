using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject[] waters;
    public GameObject[] caps;

    public class Watering
    {
        public GameObject water1;
        public GameObject water2;
        public GameObject cap;

        public bool isCap = false;

        public Watering(GameObject _water1, GameObject _water2, GameObject _cap)
        {
            water1 = _water1;
            water2 = _water2;
            cap = _cap;
        }

        public void WaterLeaking()
        {
            if (isCap)
            {
                water1.transform.localScale = new Vector3(water1.transform.localScale.x, water1.transform.localScale.y - 0.01f, water1.transform.localScale.z);
                water2.transform.localScale = new Vector3(water2.transform.localScale.x, water2.transform.localScale.y + 0.01f, water2.transform.localScale.z);
            }
        }
    }

    public Watering[] watering = new Watering [1];

    void Start()
    {
        for (int i = 0; i < watering.Length; i++) 
        {
            watering[i] = new Watering(waters[i], waters[i + 1], caps[i]);
        }
    }

    float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f) 
        {
            time = 0;
            watering[0].WaterLeaking();
        }
    }


}
