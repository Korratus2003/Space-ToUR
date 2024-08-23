using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToInstantiate());
    }

    private IEnumerator WaitToInstantiate()
    {
        System.Random rand = new System.Random();
        yield return new WaitForSeconds(rand.Next(10,30));

        Debug.Log("Jeb Asteroida");
    }
}
