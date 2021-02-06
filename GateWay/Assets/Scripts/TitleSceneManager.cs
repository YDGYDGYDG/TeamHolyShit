using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    Image tapToPlay;
    //Image gateWayName;
    RawImage moon;
    RawImage star;
    float time;
    void Start()
    {
        //gateWayName = GameObject.Find("GateWayName").GetComponent<Image>();
        tapToPlay = GameObject.Find("TapToPlay").GetComponent<Image>();
        moon = GameObject.Find("Moon").GetComponent<RawImage>();
        star = GameObject.Find("Star").GetComponent<RawImage>();
    }
    void Update()
    {
        if(time < 0.5f)
        {
            //gateWayName.GetComponent<Image>().color = new Color(1, 1, 1, 1 - time);
            tapToPlay.GetComponent<Image>().color = new Color(1, 1, 1, 1 - time);
            moon.GetComponent<RawImage>().color = new Color(1, 1, 1, 1 - time);
            star.GetComponent<RawImage>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            //gateWayName.GetComponent<Image>().color = new Color(1, 1, 1, time);
            tapToPlay.GetComponent<Image>().color = new Color(1, 1, 1, time);
            moon.GetComponent<RawImage>().color = new Color(1, 1, 1, time);
            star.GetComponent<RawImage>().color = new Color(1, 1, 1, time);
            if(time > 1f)
            {
                time = 0;
            }
        }
        time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
