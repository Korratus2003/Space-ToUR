using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("ratuje");
            player.IncreseHealth(10);
            Object.Destroy(this.gameObject);
        }
    }


}
