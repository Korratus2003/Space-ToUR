using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public void InstantiateEnemy(int enemyID)
    {
        GameObject enemy = Resources.Load<GameObject>(("Objects/Enemy" + enemyID));
        enemy.transform.position = this.transform.position;
        enemy.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        Instantiate(enemy);
        
    } 

    public void InstantiateHealth()
    {
        GameObject health = Resources.Load<GameObject>(("Objects/Health"));
        health.transform.position = this.transform.position;
        health.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        Instantiate(health);
    }
}
