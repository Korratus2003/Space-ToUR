using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
