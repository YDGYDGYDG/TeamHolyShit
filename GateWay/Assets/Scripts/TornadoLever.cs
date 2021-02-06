using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoLever : MonoBehaviour
{
    public GameObject player;
    public GameObject LeverUp;
    public GameObject LeverDown;
    public GameObject Tornado1;
    public GameObject Tornado2;
    public GameObject Tornado3;
    public GameObject Tornado4;
    AudioSource audioSource;               // 오디오 소스 연결
    public AudioClip playerTornado;        // 플레이어 토네이도 사운드

    void Start()
    {
        audioSource = GetComponent<AudioSource>();          // 오디오 소스 연결
        LeverUp.gameObject.SetActive(false);
        LeverDown.gameObject.SetActive(true);
        Tornado1.gameObject.SetActive(false);
        Tornado2.gameObject.SetActive(false);
        Tornado3.gameObject.SetActive(false);
        Tornado4.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            LeverUp.gameObject.SetActive(true);
            LeverDown.gameObject.SetActive(false);
            Tornado1.gameObject.SetActive(true);
            Tornado2.gameObject.SetActive(true);
            Tornado3.gameObject.SetActive(true);
            Tornado4.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Tornado")     // 토네이도 충돌
        {
            audioSource.clip = playerTornado;
            audioSource.Play();                       // 사운드 재생
        }
    }


}
