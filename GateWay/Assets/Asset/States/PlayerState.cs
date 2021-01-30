using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState : MonoBehaviour
{
    HookShotScript hookLine;    // 훅 연결용 변수
   

    public GameObject playerDeath;         // 플레이어 죽었을 때
    PlayerMoveController playerMoveStop;   // 무브 컨트롤러 연결

    AudioSource audioSource;               // 오디오 소스 연결
    public AudioClip playerDrop;           // 플레이어 추락 사운드
    public AudioClip plyaerMove;           // 플레이어 무브 사운드
    public AudioClip plyaerjump;           // 플레이어 점프 사운드

    // 캐릭터 부활 위치(맵에 따라 다름 인스펙터에서 조절하세요~~)
    public Vector2 playerStartPosition = new Vector2(0f, 0f);

    
    public void playerRevive()     // 부활 함수
    {
        this.gameObject.SetActive(true);            // 플레이어 다시 켜주고
        transform.position = playerStartPosition;   // 시작 위치로 이동 시켜
        playerMoveStop.Dead();                      // 이동 정지해
    }
    


    // Start is called before the first frame update
    void Start()
    {
        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 훅샷 스크립트 연결
        audioSource = GetComponent<AudioSource>();          // 오디오 소스 연결
        playerMoveStop = GetComponent<PlayerMoveController>();  // 무브 컨트롤러 연결
        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")        // 너 몬스터랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            // 이펙트도 출력해
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "Boss")        // 너 보스랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            // 이펙트도 출력해
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "Trap")        // 너 함정이랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            // 이펙트도 출력해
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "Drop")     // 너 추락했냐?
        {
            audioSource.clip = playerDrop;
            audioSource.Play();                 // 그럼 추락 사운드 재생하고
            Invoke("playerRevive", 3.0f);       // 3초 뒤에 시작 위치에 부활 시켜
        }

    }

   


    // Update is called once per frame
    void Update()
    {
        
    }



}
