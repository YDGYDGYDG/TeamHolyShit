using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPower : MonoBehaviour
{
    public GameObject powerDownObject;
    public GameObject powerVisual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            powerVisual.SetActive(false);
            powerDownObject.SetActive(false);
        }
    }
}
