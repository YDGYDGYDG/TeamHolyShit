using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{
    float rotate;
    public float speed = 1;

    void Update()
    {
        rotate = Time.deltaTime * speed;
        transform.Rotate(0, 0, rotate * 360);
    }
}
