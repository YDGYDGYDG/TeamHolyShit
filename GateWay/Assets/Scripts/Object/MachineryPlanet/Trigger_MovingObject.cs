using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_MovingObject : MonoBehaviour
{
    public Transform startPos;  // 시작 위치
    public Transform endPos;    // 끝나는 위치
    public Transform desPos;
    public float speed;

    bool triggerOn = false;

    public void TriggerOn()
    {
        transform.position = startPos.position;
        triggerOn = true;
    }

    void Start()
    {
        desPos = endPos;
    }

    void FixedUpdate()
    {
        if (triggerOn)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
            {
                if (desPos == endPos)
                {
                    desPos = startPos;
                }
                else
                {
                    desPos = endPos;
                }

            }
        }
    }
}