using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study31 : MonoBehaviour
{
    public GameObject[] cubes = new GameObject[3];

    private void OnMouseDown()
    {
        int target = Random.Range(0, 3);
        switch (target)
        {
            case 0:
                cubes[0].GetComponent<Renderer>().material.color = Color.yellow;
                cubes[1].GetComponent<Renderer>().material.color = Color.red;
                cubes[2].GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                cubes[0].GetComponent<Renderer>().material.color = Color.red;
                cubes[1].GetComponent<Renderer>().material.color = Color.yellow;
                cubes[2].GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                cubes[0].GetComponent<Renderer>().material.color = Color.red;
                cubes[1].GetComponent<Renderer>().material.color = Color.red;
                cubes[2].GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
