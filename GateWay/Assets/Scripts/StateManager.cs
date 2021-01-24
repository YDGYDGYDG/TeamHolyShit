using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    // 중요!!!
    // 실제 개발 작업에서 이펙트와 사운드 재생할 객체는 '프리팹'으로 객체를 참조하도록 한다.

    // 훅 스크립트 연결
    HookShotScript hookShot;
    HookScript hook;

    // 플레이어와 연결
    GameObject player;

    // 오디오 소스 연결
    AudioSource audioSource;

    


    // 조건 충족 시 재생될 SE들
    public AudioClip HitSE;       
    public AudioClip playerfallSE;
    public AudioClip gameOverSE;

    // 조건 충족 시 재생될 Effect들
    public ParticleSystem HitEffect;

    
    

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 오브젝트 찾아라
        player = GameObject.Find("player");
        // 오디오 소스 연결
        audioSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
