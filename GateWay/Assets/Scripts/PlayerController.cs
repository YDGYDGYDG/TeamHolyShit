using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // 캐릭터가 죽음
    public void PlayerDead()
    {
        Debug.Log("캐릭터 사망");
        gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
