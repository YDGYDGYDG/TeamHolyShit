using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRollingFire : MonoBehaviour
{
    public Transform startPos;  // 시작 위치
    public Transform endPos;    // 끝나는 위치
    public Transform desPos;

    public float speed;

    public float rotSpeed;            // 불기둥 돌리기

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;

    }


    private void Update()
    {
        //bladeRotation = Time.deltaTime;
        // bladeRotation++;
        transform.Rotate(0, 0, rotSpeed);
        //if (bladeRotation >= 360)
        //{
        //    bladeRotation = 0;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
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

