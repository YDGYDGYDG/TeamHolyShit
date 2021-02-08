using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerState : MonoBehaviour
{
    // 현재 씬 저장
    string Now_Scene;

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
        //this.gameObject.SetActive(true);         
        //// 스폰 시 저장된 위치가 있다면 그곳으로
        //Vector2 loadSavedPositon = new Vector2(PlayerPrefs.GetFloat("SavedPlayerX"), PlayerPrefs.GetFloat("SavedPlayerY"));
        //if (loadSavedPositon != null)
        //{
        //    transform.position = loadSavedPositon;
        //}
        //else
        //{
        //    transform.position = Vector2.zero;
        //}
        if (SceneManager.GetActiveScene().name == "BossStage")
        {
            this.gameObject.SetActive(true);
            //gameObject.transform.position = playerStartPosition;
            gameObject.transform.position = new Vector2(0, 0);
        }
        else
        {
            SceneManager.LoadScene(Now_Scene);
        }

    }
    


    void Start()
    {
        Now_Scene = SceneManager.GetActiveScene().name;

        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 훅샷 스크립트 연결
        audioSource = GetComponent<AudioSource>();          // 오디오 소스 연결
        playerMoveStop = GetComponent<PlayerMoveController>();  // 무브 컨트롤러 연결

        // 스폰 시 저장된 위치가 있다면 그곳으로
        //Vector2 loadSavedPositon = new Vector2(PlayerPrefs.GetFloat("SavedPlayerX"), PlayerPrefs.GetFloat("SavedPlayerY"));
        Vector2 loadSavedPositon = new Vector2(CheckPointSave.savedPositionX, CheckPointSave.savedPositionY);
        if (loadSavedPositon != null)
        {
            transform.position = loadSavedPositon;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")        // 너 몬스터랑 충돌했니??
        {
            PlayerDead();
        }

        else if (col.gameObject.tag == "Boss")        // 너 보스랑 충돌했니??
        {
            PlayerDead();
        }

        else if (col.gameObject.tag == "Trap")        // 너 함정이랑 충돌했니??
        {
            PlayerDead();
        }

        else if (col.gameObject.tag == "Drop")     // 너 추락했냐?
        {
            audioSource.clip = playerDrop;
            audioSource.Play();                 // 그럼 추락 사운드 재생하고
            Invoke("playerRevive", 3.0f);       // 3초 뒤에 시작 위치에 부활 시켜
        }

        else if (col.gameObject.tag == "TriggerWall")     // 올라갈순있고 내려갈순없는 벽(건희)
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void PlayerDead()
    {
        this.gameObject.SetActive(false);   // 그럼 뒤지삼
        hookLine.HookOFF();                 // 훅도 지워줘야지??
        if (hookLine.hookedObject)
        {
            hookLine.BreakShootableObject();
        }
        playerMoveStop.Dead();                      // 이동 정지해
        // 보스 신에서 부활
        if (SceneManager.GetActiveScene().name == "BossStage")
        {
            playerStartPosition = this.gameObject.transform.position;
        }


        // 이펙트도 출력해
        Instantiate(playerDeath, transform.position, Quaternion.identity);
        Invoke("playerRevive", 1.0f);       // 1초 뒤에 시작 위치에 부활 시켜

        
    }

    //private void OnApplicationQuit()
    //{
    //    //PlayerPrefs.DeleteAll();
        
    //}

}
