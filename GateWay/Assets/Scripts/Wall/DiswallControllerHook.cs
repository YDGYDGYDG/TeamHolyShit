using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiswallControllerHook : MonoBehaviour
{
    HookShotScript hook_script;
    public float hookDiswallTime = 0.01f;

    void Start()
    {

        hook_script = GameObject.Find("player"). GetComponent<HookShotScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // 훅이랑 충돌시 사라지는 벽
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hook")
        {
            this.gameObject.SetActive(false);
            //  Destroy(this.gameObject, hookDiswallTime);
        }
    }
}
