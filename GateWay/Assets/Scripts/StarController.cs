using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public bool star;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            star = true;
            Debug.Log("열쇠 획득");
            // this.gameObject.GetComponent<AudioSource>().Play();     // 별 획득 사운드 재생
            Destroy(this.gameObject);

        }
    }

    public
    // Update is called once per frame
    void Update()
    {
        
    }
}
