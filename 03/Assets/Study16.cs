using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study16 : MonoBehaviour
{
    // 상수
    public const int A = 10;
    public const int B = 50;
    // 퍼블릭 하면 다른 코드에서 Study16.A 따위로 호출 가능

    public int myAge = 10;

    const int NORMAL = 1;
    const int POISON = 2;
    const int STUN = 3;
    const int SLOW = 4;

    public int playerState = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
