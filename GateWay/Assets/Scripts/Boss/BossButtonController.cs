using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossButtonController : MonoBehaviour
{

    public int red;
    public int blue;
    public int grey;
    public int white;


    public bool cred;
    public bool cblue;
    public bool cgrey;
    public bool cwhite;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteKey("RedCheek");
        // PlayerPrefs.DeleteKey("BlueCheek");
        // PlayerPrefs.DeleteKey("GreyCheek");
        // PlayerPrefs.DeleteKey("WhiteCheek");
        red = PlayerPrefs.GetInt("RedCheek");
        blue = PlayerPrefs.GetInt("BlueCheek");
        grey = PlayerPrefs.GetInt("GreyCheek");
        white = PlayerPrefs.GetInt("WhiteCheek");
    }

     void Update()
    {
        if (red == 1)
        {
            PlayerPrefs.SetInt("RedCheek", red);
        }
        if (blue == 1)
        {
            PlayerPrefs.SetInt("BlueCheek", blue);
        }
        if (grey == 1)
        {
            PlayerPrefs.SetInt("GreyCheek", grey);
        }
        
        if (white == 1)
        {
            PlayerPrefs.SetInt("WhiteCheek", white);
        }
        
        if (SceneManager.GetActiveScene().name == "StageSelectScene")
        {
            red = PlayerPrefs.GetInt("RedCheek");
            blue = PlayerPrefs.GetInt("BlueCheek");
            grey = PlayerPrefs.GetInt("GreyCheek");
            white = PlayerPrefs.GetInt("WhiteCheek");
        }
    }
}
