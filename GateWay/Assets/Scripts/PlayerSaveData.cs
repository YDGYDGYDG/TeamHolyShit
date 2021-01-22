using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class PlayerSaveData : MonoBehaviour
{
    public GameObject Player;
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        Player.transform.position = new Vector3(x, y, 0);

    }

    //public PlayerData playerData;

    //[ContextMenu("To Json Data")]
    //void SavePlayerDataToJson()
    //{
    //    string jsonData = JsonUtility.ToJson(playerData, true);
    //    string path = Path.Combine(Application.dataPath, "playerData.json");
    //}

    //[ContextMenu("From Json Data")]
    //void LoadPlayerDataToJson()
    //{
    //    string path = Path.Combine(Application.dataPath, "playerData.json");
    //    string jsonData = File.ReadAllText(path);
    //    playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    //}
}

//[System.Serializable]
//public class PlayerData
//{
//    public string name;
//    public int stage;
//    public float xpos;
//    public float ypos;
//}