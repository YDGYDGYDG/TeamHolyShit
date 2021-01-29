using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    [SerializeField]
    private Slider airbar;

    public float maxAir = 10;
    public float curAir = 0;
    bool isWater;
    private float time = 0;
    float outTime = 0;

    private bool is_die = false;

    HookShotScript hookLine;    // 훅 연결용 변수(형준)
    PlayerState playerState;
    GameObject hookDisWall;




    // Start is called before the first frame update
    void Start()
    {
        hookLine = GetComponent<HookShotScript>();
        playerState = GameObject.Find("player").GetComponent<PlayerState>();

        hookDisWall = GameObject.Find("HookDisWall");
        curAir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_die)
            return;

       

        if (airbar.value >= 10)
        {
            is_die = true;
            PlayerDead();
            ResetPos();
        }
        
        if (isWater)
        {
            time += Time.deltaTime;

                if (time > 0.5)
                {
                    time = 0;
                    curAir += 5.0f;
                    airbar.value = curAir / maxAir;
                }
        }
        else
        {
            outTime += Time.deltaTime;

            if(curAir > 0)
            {
                if (outTime > 1.0)
                {
                    outTime = 0;
                    curAir -= 3.0f;
                    airbar.value = curAir / maxAir;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Water")
        {
            isWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            isWater = false;
        }
          
    }

    // 캐릭터가 죽음
    public void PlayerDead()
    {
        this.gameObject.SetActive(false);     // 캐릭터 없애주고..(형준)
        hookLine.HookOFF();                   // 훅도 지워줘야지??(형준)
        playerState.playerRevive();
        
    }

    private void ResetPos()
    {
        hookDisWall.SetActive(true);
        curAir = 0;
    }
}
