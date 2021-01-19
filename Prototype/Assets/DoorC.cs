using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorC : MonoBehaviour
{
    StarC starC;
    // Start is called before the first frame update
    void Start()
    {
        starC = GameObject.Find("Star").GetComponent<StarC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starC.star == true)
        {
            Destroy(this.gameObject);
        }
        
    }
}
