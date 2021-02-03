using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPower : MonoBehaviour
{
    public GameObject powerDownObject;
    public GameObject powerVisual;
    public GameObject powerDownEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            powerVisual.SetActive(false);
            powerDownObject.SetActive(false);
            Instantiate(powerDownEffect, transform.position, Quaternion.identity);
        }
    }
}
