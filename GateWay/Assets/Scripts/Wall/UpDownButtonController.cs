using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButtonController : MonoBehaviour
{
    public bool buttonOn;

    bool playerOn;
    bool objectOn;

    float speed = 0.01f;
    float maxSpeed = 0.03f;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {

        startPos = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerOn = true;
        }
        else if (collision.transform.tag == "Object")
        {
            objectOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerOn = false;
        }
        else if (collision.transform.tag == "Object")
        {
            objectOn = false;
        }
    }
    void ButtonOn()
    {
        buttonOn = true;
        if ( transform.position.y > startPos.y - maxSpeed)
        gameObject.transform.Translate(0, -speed, 0);
    }
    void ButtonOff()
    {
        buttonOn = false;
        if ( transform.position.y < startPos.y + maxSpeed)
        gameObject.transform.Translate(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOn || objectOn)
        {

            ButtonOn();
        }
        else if (!playerOn && !objectOn)
        {
            ButtonOff();
        }
    }
}
