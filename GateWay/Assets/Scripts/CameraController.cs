using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float heightMax = 1000;
    public float heightMin = -1000;
    public float widthMax = 1000;
    public float widthMin = -1000;

    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        if (transform.position.x < widthMax && transform.position.x > widthMin && transform.position.y < heightMax && transform.position.y > heightMin)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
