using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureRotateGame : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;

    public static bool youWin;

    void Start()
    {
        winText.SetActive(false);
        youWin = false;
        for (int i = 0; i < 9; i++)
        {
            int j = Random.Range(0, 3);
            pictures[i].transform.Rotate(0f, 0f, j * 90f);
        }             
    }

    void Update()
    {        
        if (pictures[0].rotation.z < 0.1 &&
        pictures[1].rotation.z < 0.1 &&
        pictures[2].rotation.z < 0.1 &&
        pictures[3].rotation.z < 0.1 &&
        pictures[4].rotation.z < 0.1 &&
        pictures[5].rotation.z < 0.1 &&
        pictures[6].rotation.z < 0.1 &&
        pictures[7].rotation.z < 0.1 &&
        pictures[8].rotation.z < 0.1)        
        {
            youWin = true;
            winText.SetActive(true);
        }
        
        
    }
}
