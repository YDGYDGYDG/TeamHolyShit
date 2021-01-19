using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarC : MonoBehaviour
{
    public bool star;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            star = true;
            Debug.Log("열쇠 획득");
            Destroy(this.gameObject);

        }
    }

    public
    // Update is called once per frame
    void Update()
    {
        
    }
}
