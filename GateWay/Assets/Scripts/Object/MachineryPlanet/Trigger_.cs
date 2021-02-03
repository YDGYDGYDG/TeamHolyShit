using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_ : MonoBehaviour
{
    public Trigger_Door [] triggerObject;
    public Trigger_MovingObject [] movingObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < triggerObject.Length; i++)
            {
                if (triggerObject[i])
                {
                    triggerObject[i].TriggerOn();
                }
            }
            for (int i = 0; i < movingObject.Length; i++)
            {
                if (movingObject[i]) 
                {
                    movingObject[i].TriggerOn();
                }
            }
            this.gameObject.SetActive(false);
        }
    }

}
