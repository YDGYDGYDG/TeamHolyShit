using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    public Transform camera;

    MeshRenderer renderer;

    public float speed = 0.03f;

    float offsetX;
    float offsetY;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        offsetX = camera.position.x;
        offsetY = camera.position.y;
    }

    void Update()
    {
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetX * speed, offsetY * speed));
        offsetX = camera.position.x;
        offsetY = camera.position.y;

    }
}
