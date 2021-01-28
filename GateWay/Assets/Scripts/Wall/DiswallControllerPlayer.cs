using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiswallControllerPlayer : MonoBehaviour
{
    
    HookShotScript hook_script;
    public float playerDiswallTime = 0.5f;

    void Start()
    {

        hook_script = GameObject.Find("player").GetComponent<HookShotScript>();
    }
    // 캐릭터랑 충돌 시 사라지는 벽
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, playerDiswallTime);
            hook_script.HookOFF();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
