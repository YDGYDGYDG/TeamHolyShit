using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControllerCa : MonoBehaviour
{
    public GameObject[] waters;
    public GameObject[] caps;
    public GameObject[] leaks;

    public GameObject cap;
    public CameraController cameraController;
    public bool cameraPlus;
    public bool cameraMinus;
    public Camera mainCamera;

    public class Watering
    {

        public GameObject water1;
        public GameObject water2;
        public GameObject cap;
        public GameObject leak;
        

        public bool isCap = false;

        public Watering(GameObject _water1, GameObject _water2, GameObject _cap, GameObject _leak)
        {
            water1 = _water1;
            water2 = _water2;
            cap = _cap;
            leak = _leak;
        }
        public void WaterLeaking()
        {
            if (isCap && water1.transform.localScale.y > 0)
            {
                

                if (water1.transform.position.y + water1.GetComponent<SpriteRenderer>().bounds.size.y
                >
                water2.transform.position.y + water2.GetComponent<SpriteRenderer>().bounds.size.y)
                {
                    leak.SetActive(true);
                    water1.transform.localScale = new Vector3(water1.transform.localScale.x, water1.transform.localScale.y - 0.005f, water1.transform.localScale.z);
                    water2.transform.localScale = new Vector3(water2.transform.localScale.x, water2.transform.localScale.y + 0.005f, water2.transform.localScale.z);
                }
                else
                {
                    isCap = false;
                    leak.SetActive(false);
                }
            }
            else
            {
                isCap = false;
                leak.SetActive(false);
            }
        }

        public void Update()
        {
            if (cap.gameObject.activeInHierarchy == false)
            {
                isCap = true;
            }
        }
    }

    public Watering[] watering = new Watering [1];

    void Start()
    {
        for (int i = 0; i < watering.Length; i++) 
        {
            watering[i] = new Watering(waters[i], waters[i + 1], caps[i], leaks[i]);
        }
    }

    float flag = 0;
    float cameraTime = 0;
    float time;
    float distanceX;
    
    void Update()
    {
        if(cap.activeSelf == false)
        {
            if(flag == 0)
            {
                cameraPlus = true;
                flag = 1;
            }
        }

        if (cameraPlus)
        {
            cameraController.enabled = false;
            distanceX = -mainCamera.transform.position.x / 100.0f;

            float cameraSize = 40.03f;
            float cameraY = -25.0f;
            if (mainCamera.orthographicSize < cameraSize)
            {
                mainCamera.orthographicSize += 0.326f;
                mainCamera.transform.Translate(distanceX, -0.25f, 0);
            }
            else
            {
                cameraPlus = false;
                cameraMinus = true;
            }
        }

        if(cameraMinus)
        { 
            cameraTime += Time.deltaTime;
            if (cameraTime >= 3.0f)
            {
                if (mainCamera.orthographicSize > 7.43f)
                {
                    mainCamera.orthographicSize -= 0.326f;
                    mainCamera.transform.Translate(distanceX, 0.25f, 0);
                }
                else
                {
                    cameraController.enabled = true;
                    cameraMinus = false;
                }
            }
        }
        for (int i = 0; i < watering.Length; i++)
        {
            watering[i].Update();
        }

        time += Time.deltaTime;
        if (time > 0.01f) 
        {
            time = 0;
            watering[0].WaterLeaking();
        }
    }


}
