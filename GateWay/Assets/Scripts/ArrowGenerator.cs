using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject Lightning;  //프리팹을 이용해 만들 객체

    void Start()
    {
        StartCoroutine(CreateLightningRoutine());
    }

    IEnumerator CreateLightningRoutine()
    {
        while (true)
        {
            CreateLightning();
            yield return new WaitForSeconds(1);
        }
    }

    private void CreateLightning()
    {
        Vector3 pos = (new Vector3(UnityEngine.Random.Range(0.0f, 48.0f), 25f, 0));
        pos.z = 0.0f;
        Instantiate(Lightning, pos, Quaternion.identity);
    }


}
