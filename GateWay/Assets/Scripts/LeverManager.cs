using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject LeverUp;
    public GameObject LeverDown;
    public GameObject wall_1;
    public GameObject wall_2;
    public GameObject wall_3;
    public GameObject wall_4;
    public GameObject wall_5;
    public GameObject wall_6;
    public GameObject wall_7;
    public GameObject wall_8;
    public GameObject wall_9;
    public GameObject wall_10;
    public GameObject wall_11;
    public GameObject wall_12;
    public GameObject wall_13;
    public GameObject wall_14;
    public GameObject wall_15;
    public GameObject wall_16;
    public GameObject wall_17;
    float disappearTime = 10.0f;  // 3초뒤 레버가 다시 돌아옴   

    void Start()
    {
        LeverUp.gameObject.SetActive(false);
        LeverDown.gameObject.SetActive(true);
        wall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
    }
    void Appear()  // 벽 다시 나타나는 함수
    {
        LeverUp.gameObject.SetActive(true);
        LeverDown.gameObject.SetActive(false);
        wall_1.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_2.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_3.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_4.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_5.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_6.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_7.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_8.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_9.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_10.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_11.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_12.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_13.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_14.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_15.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_16.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_17.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
    void DisAppear() // 벽이 사라지는 함수 투명도를 0으로 조절하는 것 뿐임
    {
        LeverUp.gameObject.SetActive(false);
        LeverDown.gameObject.SetActive(true);
        wall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_12.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_13.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_14.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_15.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_16.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_17.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
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
