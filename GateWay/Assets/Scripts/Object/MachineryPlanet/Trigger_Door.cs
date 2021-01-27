using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Door : MonoBehaviour
{
    public float speed;
    public Transform desPos;
    bool triggerOn = false;

    public void TriggerOn()
    {
        triggerOn = true;
    }

    void FixedUpdate()
    {
        if(triggerOn)
            transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, desPos.position) <= 1)
            triggerOn = false;
    }

}
