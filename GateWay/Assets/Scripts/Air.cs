using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    [SerializeField]
    private Slider airbar;

    private float maxAir = 10;
    private float curAir = 0;
    bool isWater;
    private float time = 0;
    float outTime = 0;


    // Update is called once per frame
    void Update()
    {
        if (isWater)
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                time = 0;
                curAir += 5.0f;
                airbar.value = curAir / maxAir;
            }
        }
        else
        {
            outTime -= Time.deltaTime;
            if(outTime > 0.5)
            {
                outTime = 0;
                curAir -= 5.0f;
                airbar.value = curAir / maxAir;
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("물이야");
            isWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("아니야");
            isWater = false;
        }
          
    }
}
