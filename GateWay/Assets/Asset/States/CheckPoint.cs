using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject Check;     // 위치 저장 시 나올 이펙트

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("SavedPlayerX", transform.position.x);
            PlayerPrefs.SetFloat("SavedPlayerY", transform.position.y);
            Instantiate(Check, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
