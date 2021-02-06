using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindGenerator : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;
    Image Lefttornado; 
    Image Lefttornado1; 
    Image Righttornado; 
    Image Righttornado1;
    AudioSource audioSource;               // 오디오 소스 연결
    public AudioClip playerTornado;        // 플레이어 토네이도 사운드

    float timeSpan;  // 경과 시간
    float WindReset; // 바람 초기화
    float LeftWindTime = 3.0f;
    float RightWindTime = 3.0f;

    public void RightWind()
    {
        Lefttornado.gameObject.SetActive(true);
        Lefttornado1.gameObject.SetActive(true);
        Righttornado.gameObject.SetActive(false);
        Righttornado1.gameObject.SetActive(false);
        rigid.AddForce(Vector3.right * 0.4f, ForceMode2D.Impulse);
        audioSource.clip = playerTornado;
        audioSource.Play();
    }
    public void LeftWind()
    {
        Lefttornado.gameObject.SetActive(false);
        Lefttornado1.gameObject.SetActive(false);
        Righttornado.gameObject.SetActive(true);
        Righttornado1.gameObject.SetActive(true);
        rigid.AddForce(Vector3.left * 0.4f, ForceMode2D.Impulse);
        audioSource.clip = playerTornado;
        audioSource.Play();
    }
    public void UpWind()
    {
        rigid.AddForce(Vector3.up * 0.4f, ForceMode2D.Impulse);
    }
    public void DownWind()
    {
        rigid.AddForce(Vector3.down * 0.4f, ForceMode2D.Impulse);
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Lefttornado = GameObject.Find("LeftTornado").GetComponent<Image>();
        Lefttornado1 = GameObject.Find("LeftTornado1").GetComponent<Image>();
        Righttornado = GameObject.Find("RightTornado").GetComponent<Image>();
        Righttornado1 = GameObject.Find("RightTornado1").GetComponent<Image>();
        Lefttornado.gameObject.SetActive(false);
        Lefttornado1.gameObject.SetActive(false);
        Righttornado.gameObject.SetActive(false);
        Righttornado1.gameObject.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();
        timeSpan = 0.0f;     
    }

    void Update()
    {
        WindReset = RightWindTime + LeftWindTime;

        timeSpan += Time.deltaTime;
        if (timeSpan < LeftWindTime)
        LeftWind();
     
        if (timeSpan >= RightWindTime)
        RightWind();
    
        if (timeSpan > WindReset)
        timeSpan = 0;
    } 
}
