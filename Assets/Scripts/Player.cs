using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float mouseSensitivity = 2f;
    private float health = 100;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, 1, -4);
    }

    // Update is called once per frame
    void Update()
    {


        Move();
    }

    void FixedUpdate()
    {
        

    }


    private void Move()
    {

        //pobranie ruchów myszy
        float moveHorizontal = Input.GetAxis("Mouse X") * 8f * mouseSensitivity;
        float moveVertical = Input.GetAxis("Mouse Y") * 8f * mouseSensitivity;

        //ruch
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //blokda ¿eby nie wyszed³ za kamere
        float clampedX = Mathf.Clamp(this.transform.position.x, -8f, 8f);
        float clampedZ = Mathf.Clamp(this.transform.position.z, -4.3f, 4.3f);

        this.transform.position = new Vector3(clampedX, this.transform.position.y, clampedZ);


        //nachylenie
        //float tiltAngle = 30.0f;
        //if (movement != Vector3.zero)
        //{
        //    float tilt = movement.x * tiltAngle;
        //    transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, -tilt);
        //}
        //else
        //{
        //    transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
        //}
        //Quaternion currentRotation = transform.GetChild(0).transform.localRotation;
        //transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z);
    }

    public float GetHealth()
    {
        return health;
    }

    public void IncreaseHealth(float hp) {
        health += hp;
    }
    public void DecreaseHealth(float hp) {
    health -= hp;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //zrób coœ jeszcze
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            DecreaseHealth(50f);
            Destroy(other.gameObject); 
        }
    }
}
