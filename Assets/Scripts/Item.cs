using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    
    private float speed = 0.7f;

    private void Start()
    {
        Destroy(this.gameObject, 45f);
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
