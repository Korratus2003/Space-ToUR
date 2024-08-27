using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    float health = 100f;
    float points = 20f;
    float speed = 1f;

    public void setPoints(float points)
    {
        this.points = points;
    }

    public void setHealth(float health) {  
        this.health = health; 
    }

    public void setSpeed(float speed) { 
        this.speed = speed;
    }

    private void Start()
    {
        Destroy(this.gameObject, 60f);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void DecreseHealth(float health)
    {
        this.health -= health;
        if (this.health <= 0)
            Destroy(this.gameObject);
        
    }

    private void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 0.4f * speed);
    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LvlController>().AddPoints(points);
    }
}
