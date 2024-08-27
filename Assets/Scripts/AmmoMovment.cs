using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoMovment : MonoBehaviour
{
    private float speed = 10f;
    private float damage = 25f;
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            other.GetComponent<Enemy>().DecreseHealth(damage);
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("MainCamera"))
            Destroy(this.gameObject);
    }
}
