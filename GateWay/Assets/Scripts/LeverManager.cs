using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject LeverUp1;
    public GameObject LeverDown1;
    public GameObject LeverUp2;
    public GameObject LeverDown2;
    public GameObject wall_0;
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
    public GameObject wall_18;
    public GameObject wall_19;
    public GameObject wall_20;
    public GameObject wall_21;
    public GameObject wall_22;
    public GameObject wall_23;
    public GameObject wall_24;
    public GameObject wall_25;
    public GameObject wall_26;
    public GameObject wall_27;
    public GameObject wall_28;
    public GameObject wall_29;
    public GameObject wall_30;
    public GameObject wall_31;
    public GameObject wall_32;
    public GameObject wall_33;
    public GameObject wall_34;
    public GameObject wall_35;
    public GameObject wall_36;
    public GameObject wall_37;
    public GameObject wall_38;
    public GameObject wall_39;
    
    float disappearTime = 20.0f;  // 20초뒤 레버가 다시 돌아옴   

    void Update()
    {

    }
    void Start()
    {
        LeverUp1.gameObject.SetActive(false);
        LeverDown1.gameObject.SetActive(true);
        LeverUp2.gameObject.SetActive(false);
        LeverDown2.gameObject.SetActive(true);
        wall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
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
        wall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_20.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_21.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_22.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_23.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_24.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_25.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_26.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_27.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_28.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_29.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_30.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_31.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_32.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_33.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_34.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_35.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_36.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_37.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_38.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_39.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
    }
    void Appear()  // 벽 다시 나타나는 함수
    {
        LeverUp1.gameObject.SetActive(true);
        LeverDown1.gameObject.SetActive(false);
        LeverUp2.gameObject.SetActive(true);
        LeverDown2.gameObject.SetActive(false);
        wall_0.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_1.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_2.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_3.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_4.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_5.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_6.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_7.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_8.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_9.GetComponent<SpriteRenderer>().material.color = Color.white;
        wall_10.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_11.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_12.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_13.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_14.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_15.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_16.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_17.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_18.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_19.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_20.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_21.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_22.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_23.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_24.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_25.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_26.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_27.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_28.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_29.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_30.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_31.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_32.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_33.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_34.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_35.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_36.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_37.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_38.GetComponent<SpriteRenderer>().material.color =Color.white;
        wall_39.GetComponent<SpriteRenderer>().material.color = Color.white;   
    }
    void DisAppear() // 벽이 사라지는 함수 투명도를 0으로 조절하는 것 뿐임
    {
        LeverUp1.gameObject.SetActive(false);
        LeverDown1.gameObject.SetActive(true);
        LeverUp2.gameObject.SetActive(false);
        LeverDown2.gameObject.SetActive(true);
        wall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
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
        wall_18.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_19.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_20.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_21.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_22.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_23.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_24.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_25.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_26.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_27.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_28.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_29.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_30.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_31.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_32.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_33.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_34.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_35.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_36.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_37.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_38.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        wall_39.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
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
