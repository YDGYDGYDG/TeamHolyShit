using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSetActiveController : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject grey;
    public GameObject white;
    public GameObject whiteWall;

    public float time;

    public float timeMax = 1;

    BossController mod;
    // Start is called before the first frame update
    void Start()
    {
        red.SetActive(false);
        blue.SetActive(false);
        grey.SetActive(false);
        white.SetActive(false);
        mod = GameObject.Find("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mod.mod == 1)
        {
            time += Time.deltaTime;
            if ( time < timeMax)
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
            else
            {
                red.SetActive(true);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
        }
        else if (mod.mod == 2)
        {
            time += Time.deltaTime;
            if (time < timeMax)
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
            else
            {
                red.SetActive(false);
                blue.SetActive(true);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
        }
        else if (mod.mod == 3)
        {
            time += Time.deltaTime;
            if (time < timeMax)
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
            else
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(true);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
        }
        else if (mod.mod == 4)
        {
            time += Time.deltaTime;
            if (time < timeMax)
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(false);
                whiteWall.SetActive(true);
            }
            else
            {
                red.SetActive(false);
                blue.SetActive(false);
                grey.SetActive(false);
                white.SetActive(true);
                whiteWall.SetActive(false);

            }
        }
    }
}
