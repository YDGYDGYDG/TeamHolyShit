using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMirror : MonoBehaviour
{
    int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hook") 
        {
            count += 1;
            transform.rotation = Quaternion.Euler(0, 0, 60 * count);
            Debug.Log(count);
            if (count >= 6) count = 0;
        }
    }
}
