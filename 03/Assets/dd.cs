using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dd : MonoBehaviour
{

    int a = 0;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(a);
        refqff(ref a);
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void refqff(ref int num)
    {
        num += 1;
    }
}
