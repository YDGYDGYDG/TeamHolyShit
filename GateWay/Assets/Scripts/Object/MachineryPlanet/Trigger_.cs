using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_ : MonoBehaviour
{
    public Trigger_Door triggerObject;
    public Trigger_MovingObject movingObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(triggerObject) triggerObject.TriggerOn();
            if(movingObject) movingObject.TriggerOn();
            this.gameObject.SetActive(false);
        }
    }

}
