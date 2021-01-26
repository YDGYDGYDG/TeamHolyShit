using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public bool dropFire = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 아래로 떨어짐
        if(dropFire)
        transform.Translate(0, -0.1f, 0);

        // 화면밖으로 나가면 소멸
        if (transform.position.y < -50.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
