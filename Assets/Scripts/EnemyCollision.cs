using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
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
            Debug.Log("boooooom");
            player.DecreaseHealth(10);
            Object.Destroy(this.gameObject);
        }
    }
    
}
