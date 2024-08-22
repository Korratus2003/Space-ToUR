using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public void InstantinateEnemy(int enemyID)
    {
        Debug.Log("Enemy"+enemyID);
        GameObject enemy = Resources.Load<GameObject>(("Objects/Enemy" + enemyID));
        enemy.transform.position = this.transform.position;
        Instantiate(enemy);
        
    } 
}
