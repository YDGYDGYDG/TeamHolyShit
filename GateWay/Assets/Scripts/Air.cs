using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    [SerializeField]
    private Image airbar;

    public float maxAir = 100;
    public float curAir = 100;
    bool isWater;
    private float time = 0;
    float outTime = 0;

    private bool is_die = false;

    HookShotScript hookLine;    // 훅 연결용 변수(형준)
    PlayerState playerState;
    GameObject hookDisWall;
    public GameObject star;




    // Start is called before the first frame update
    void Start()
    {
        hookLine = GetComponent<HookShotScript>();
        playerState = GameObject.Find("player").GetComponent<PlayerState>();

        hookDisWall = GameObject.Find("HookDisWall");
    }

    // Update is called once per frame
    void Update()
    {


        if (is_die)
            return;

       

        if (curAir <= 0)
        {
            is_die = true;
            ResetObject();
            PlayerDrown();
            
        }
        
        if (isWater)
        {
            time += Time.deltaTime;

                if (time > 0.5)
                {
                    time = 0;
                    curAir -= 5.0f;
                }
        }
        else
        {
            outTime += Time.deltaTime;

            if(curAir < 100)
            {
                if (outTime > 1.0)
                {
                    outTime = 0;
                    curAir += 3.0f;
                }
            }
        }
        airbar.fillAmount = curAir / maxAir;
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

    void Revive()
    {
        playerState.playerRevive();
    }

    // 캐릭터 익사
    public void PlayerDrown()
    {
        this.gameObject.SetActive(false);     // 캐릭터 없애주고..(형준)
        hookLine.HookOFF();                   // 훅도 지워줘야지??(형준)
        Invoke("Revive", 1.0f);
        is_die = false;
    }

    private void ResetObject()
    {
        Debug.Log("tq");
        hookDisWall.SetActive(true);
        curAir = 100;
        star.SetActive(true);
    }
}
