using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Lever;
    public GameObject wall;
    float disappearTime = 3.0f;  // 3초뒤 레버가 다시 돌아옴   

    void Appear()
    {
        Lever.GetComponent<SpriteRenderer>().material.color = Color.red;
        wall.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
    void DisAppear()
    {
        Lever.GetComponent<SpriteRenderer>().material.color = Color.blue;
        wall.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            Appear();
            Invoke("DisAppear", disappearTime);
        }
    }
}
