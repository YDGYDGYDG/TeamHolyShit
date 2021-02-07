using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossButtonCheek : MonoBehaviour
{
    BossButtonController bb;
    // Start is called before the first frame update
    void Start()
    {
        bb = GameObject.Find("BossButtonController").GetComponent<BossButtonController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "InfinityStorm4-5")
        {
            bb.white = true;
        }
        else if (SceneManager.GetActiveScene().name == "LavaStage4")
        {
            bb.red = true;
        }
        else if (SceneManager.GetActiveScene().name == "MachineryStage5")
        {
            bb.grey = true;
        }
        else if (SceneManager.GetActiveScene().name == "WaterPlanet4")
        {
            bb.blue = true;
        }

        // Update is called once per frame
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
