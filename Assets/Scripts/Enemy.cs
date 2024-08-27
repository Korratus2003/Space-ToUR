using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 100f;
    private void Start()
    {
        Destroy(this.gameObject, 60f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 0.4f);
    }

    public void DecreseHealth(float health)
    {
        this.health -= health;
        if (this.health <= 0)
            Destroy(this.gameObject);
        
    }
}
