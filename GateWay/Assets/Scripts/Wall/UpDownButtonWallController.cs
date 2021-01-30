using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButtonWallController : MonoBehaviour
{
    public UpDownButtonController buttonOn;
    float move = 0.01f;
    public float moveMax;

    public float speed = 0.01f;

    public bool doorUp;


    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        moveMax = gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpDownTrigger();
    }
    public void UpDownTrigger()
    {
        if (doorUp)
        {
            if (buttonOn.buttonOn)
            {
                if (transform.position.y < startPos.y + moveMax)
                {
                    transform.Translate(0, speed, 0);
                }
            }
            else
            {
                if (transform.position.y > startPos.y)
                {
                    transform.Translate(0, -speed, 0);
                }
            }

        }
        else
        {
            if (buttonOn.buttonOn)
            {
                if (transform.position.y > startPos.y - moveMax)
                {
                    transform.Translate(0, -speed, 0);
                }
            }
            else
            {
                if (transform.position.y < startPos.y)
                {
                    transform.Translate(0, speed, 0);
                }
            }

        }
    }
}
