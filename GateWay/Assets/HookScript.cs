using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    HookShotScript hookShot;
    DistanceJoint2D joint2D;

    void Start()
    {
        hookShot = GameObject.Find("player").GetComponent<HookShotScript>();
        joint2D = GetComponent<DistanceJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            joint2D.enabled = true;
            hookShot.isAttach = true;
        }
    }
}
