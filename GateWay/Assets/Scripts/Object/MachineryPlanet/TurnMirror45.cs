using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMirror45 : MonoBehaviour
{
    public int count = 0;
    public GameObject touchEffect;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 60 * count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hook")
        {
            count += 1;
            transform.rotation = Quaternion.Euler(0, 0, 45 * count);
            if (count >= 6) count = 0;
            Instantiate(touchEffect, collision.transform.position, Quaternion.identity);
        }
    }
}
