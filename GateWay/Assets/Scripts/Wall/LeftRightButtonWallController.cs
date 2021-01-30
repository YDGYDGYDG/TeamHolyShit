using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightButtonWallController : MonoBehaviour
{
    public LeftRightButtonController buttonOn;
    float move = 0.01f;
    public float moveMax;

    public float speed = 0.01f;

    public bool doorRight;


    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        moveMax = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        LeftRightTrigger();
    }
    public void LeftRightTrigger()
    {
        if (doorRight)
        {
            if (buttonOn.buttonOn)
            {
                if (transform.position.x < startPos.x + moveMax)
                {
                    transform.Translate(speed, 0, 0);
                }
            }
            else
            {
                if (transform.position.x > startPos.x)
                {
                    transform.Translate(-speed, 0, 0);
                }
            }

        }
        else
        {
            if (buttonOn.buttonOn)
            {
                if (transform.position.x > startPos.x - moveMax)
                {
                    transform.Translate(-speed, 0, 0);
                }
            }
            else
            {
                if (transform.position.x < startPos.x)
                {
                    transform.Translate(speed, 0, 0);
                }
            }

        }
    }
}
