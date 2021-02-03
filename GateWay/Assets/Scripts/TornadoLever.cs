using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoLever : MonoBehaviour
{
    public GameObject player;
    public GameObject LeverUp;
    public GameObject LeverDown;
    public GameObject Tornado1;
    public GameObject Tornado2;
    public GameObject Tornado3;
    public GameObject Tornado4;

    void Start()
    {
        LeverUp.gameObject.SetActive(false);
        LeverDown.gameObject.SetActive(true);
        Tornado1.gameObject.SetActive(false);
        Tornado2.gameObject.SetActive(false);
        Tornado3.gameObject.SetActive(false);
        Tornado4.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            LeverUp.gameObject.SetActive(true);
            LeverDown.gameObject.SetActive(false);
            Tornado1.gameObject.SetActive(true);
            Tornado2.gameObject.SetActive(true);
            Tornado3.gameObject.SetActive(true);
            Tornado4.gameObject.SetActive(true);
        }
    }
}
