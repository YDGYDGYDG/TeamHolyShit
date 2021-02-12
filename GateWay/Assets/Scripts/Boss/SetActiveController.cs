using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveController : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;


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
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(true);
        }
    }
}
