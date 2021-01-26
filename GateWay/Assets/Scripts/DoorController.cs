using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    StarController starC;
    // Start is called before the first frame update
    void Start()
    {
        starC = GameObject.Find("StarPrefab").GetComponent<StarController>();
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
