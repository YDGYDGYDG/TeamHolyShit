using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3.0f);     // 3초마다 클론 오브젝트를 삭제해라
    }
}
