using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveController : MonoBehaviour
{
    public GameObject fireO;
    public GameObject fireT;


    // Start is called before the first frame update
    void Start()
    {

    }
    float time = 0;
    public float maxtime = 4;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= maxtime)
        {
            time = 0;
            fireO.SetActive(true);
            fireT.SetActive(true);
        }
    }
}
