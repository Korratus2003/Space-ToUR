using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public float speed = 10f;
    public float delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", delay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
