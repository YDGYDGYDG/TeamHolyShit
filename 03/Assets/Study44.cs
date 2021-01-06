using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study44 : MonoBehaviour
{
    // transform.Find를 이용해 여러개의 게임오브젝트의 정보를 한 번에 찾기
    // transform은 자식으로 구성된 모든 오브젝트 리스트를 가지고 있다
    
    // 오브젝트 리스트 작성: UI를 관리해 줄 오브젝트!
    List<GameObject> uiList = new List<GameObject>();

    Transform uiTransorm;

    // Start is called before the first frame update
    void Start()
    {
        // UI 매니저를 찾는다
        uiTransorm = transform.Find("UIMng");

        // UI매니저 내 모든 UI 찾기
        foreach(Transform ui in uiTransorm)
        {
            // 관리할 수 있도록 리스트에 추가
            uiList.Add(ui.gameObject);
            // 그 다음 활성 디폴트 상태는 off로
            ui.gameObject.SetActive(false);
        }

    }

    void ShowUI(int uiIndex)
    {
        uiList[uiIndex].SetActive(true);
    }

    void CloseUI()
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            uiList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowUI(0);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowUI(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowUI(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }

    }
}
