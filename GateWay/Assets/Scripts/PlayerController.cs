using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HookShotScript hookLine;    // 훅 연결용 변수(형준)



    // Start is called before the first frame update
    void Start()
    {

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 스크립트 연결(형준)




    }
    // 캐릭터가 죽음
    public void PlayerDead()
    {
        Debug.Log("캐릭터 사망");
        this.gameObject.SetActive(false);     // 캐릭터 없애주고..(형준)
        hookLine.HookOFF();                   // 훅도 지워줘야지??(형준)
        

        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
