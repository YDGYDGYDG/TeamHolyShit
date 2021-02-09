using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSetOff : MonoBehaviour
{
    GameObject Bgm2;

    // Start is called before the first frame update
    void Start()
    {
        Bgm2 = GameObject.Find("UI BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Bgm2.SetActive(false);
    }

}
