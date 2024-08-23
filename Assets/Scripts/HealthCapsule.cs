using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCapsule : Item
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")){
            other.GetComponent<Player>().IncreaseHealth(20f);
            Destroy(this.gameObject);
        }
            
    }
}
