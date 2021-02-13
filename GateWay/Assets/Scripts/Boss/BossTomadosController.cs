using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTomadosController : MonoBehaviour
{
    public GameObject tomado1;
    public GameObject tomado2;
    float time1;
    public float hidetime1 = 1.0f;
    public float showtime1 = 1.5f;
    float time2;
    public float hidetime2 = 1.3f;
    public float showtime2 = 1.8f;

    // Start is called before the first frame update
    void Start()
    {
        tomado1.SetActive(false);   
        tomado2.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        time1 += Time.deltaTime;
        if ( time1 > hidetime1)
        {
            tomado1.SetActive(true);
            if (time1 > showtime1)
            {
                tomado1.SetActive(false);
            }
            if ( time1 > hidetime2)
            {
                tomado2.SetActive(true);
                if (time1 > showtime2)
                {
                    tomado2.SetActive(false);
                    time1 = 0;
                }
            }
        }
    }
}
