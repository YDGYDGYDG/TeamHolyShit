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
        if(collision.gameObject.name == "player")
        {
            if (SceneManager.GetActiveScene().name == "InfinityStorm4-5")
            {
                bb.white = 1;
            }
            if (SceneManager.GetActiveScene().name == "LavaStage4")
            {
                bb.red = 1;
            }
            if (SceneManager.GetActiveScene().name == "MachineryStage5")
            {
                bb.grey = 1;
            }
            if (SceneManager.GetActiveScene().name == "WaterPlanet4")
            {
                bb.blue = 1;
            }
        }
        // Update is called once per frame
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "player")
        {
            if (SceneManager.GetActiveScene().name == "InfinityStorm4-5")
            {
                bb.white = 1;
            }
            if (SceneManager.GetActiveScene().name == "LavaStage4")
            {
                bb.red = 1;
            }
            if (SceneManager.GetActiveScene().name == "MachineryStage5")
            {
                bb.grey = 1;
            }
            if (SceneManager.GetActiveScene().name == "WaterPlanet4")
            {
                bb.blue = 1;
            }
        }
        // Update is called once per frame
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
