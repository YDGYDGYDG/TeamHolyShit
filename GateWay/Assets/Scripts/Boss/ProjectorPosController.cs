using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorPosController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time= 0;
    public float speed = 1;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.Rotate(0, 0, speed);
    }
}
