using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPower : MonoBehaviour
{
    public R_LaserProjector laserProjector;
    public GameObject laser;
    public GameObject powerVisual;
    public GameObject powerDownEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            powerVisual.SetActive(false);
            laser.SetActive(false);
            laserProjector.PowerOff();
            Instantiate(powerDownEffect, transform.position, Quaternion.identity);
        }
    }
}
