using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightButtonController : MonoBehaviour
{
    public bool buttonOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            buttonOn = true;
            gameObject.transform.Translate(0, -0.05f, 0);
        }
        else if (collision.transform.tag == "Object")
        {
            buttonOn = true;
            gameObject.transform.Translate(0, -0.05f, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            buttonOn = false;
            gameObject.transform.Translate(0, 0.05f, 0);
        }
        else if (collision.transform.tag == "Object")
        {
            buttonOn = false;
            gameObject.transform.Translate(0, 0.05f, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
