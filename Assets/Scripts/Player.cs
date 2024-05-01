using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 100;
    public GameObject[] guns;
    private float lastFireTime;
    public float fireCooldown = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time - lastFireTime > fireCooldown)
            {
                foreach (var g in guns)
                {
                    g.GetComponent<Gun>().Fire();
                }
                lastFireTime = Time.time;
            }
        }
    }

    public void IncreseHealth(int health)
    {
        this.health += health;
        if (this.health > 100) this.health = 100;
        Debug.Log(this.health);
    }
    public void DecreaseHealth(int health)
    {
        this.health -= health;
        Debug.Log(this.health);
        if(this.health <= 0 )Destroy(this.gameObject);
    }

}
