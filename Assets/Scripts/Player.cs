using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float health = 100;
    private float rotationY;


    public float moveSpeed = 10f;
    public float mouseSensitivity = 1f;
    public GameObject HUDController;
    Vector3 previousPosition; // u¿ywane do nachylenia dziecka

    // Start is called before the first frame update
    void Start()
    {
        HUDController.GetComponent<HUDController>().UpdateHealth(GetHealth());
        previousPosition = transform.GetChild(0).position;
        this.transform.position = new Vector3(0, 0, -4);
        this.transform.rotation = Quaternion.Euler(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Tilt();
    }


    private void Move()
    {

        //pobranie ruchów myszy
        float moveHorizontal = Input.GetAxis("Mouse X") * 2f * mouseSensitivity;
        float moveVertical = Input.GetAxis("Mouse Y") * 2f * mouseSensitivity;

        //ruch
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //blokda ¿eby nie wyszed³ za kamere
        float clampedX = Mathf.Clamp(this.transform.position.x, -8f, 8f);
        float clampedZ = Mathf.Clamp(this.transform.position.z, -4.3f, 4.3f);

        this.transform.position = new Vector3(clampedX, this.transform.position.y, clampedZ);

        //rotacja
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, rotationY , transform.rotation.y), Time.deltaTime * 5f);

    }

    private void Tilt()
    {

        // Oblicz wektor ruchu dziecka
        Vector3 childMovement = transform.GetChild(0).position - previousPosition;

        // Zaktualizuj poprzedni¹ pozycjê
        previousPosition = transform.GetChild(0).position;

        // Pobierz lokalny przód dziecka
        Vector3 childRight = transform.GetChild(0).right;

        // SprawdŸ, czy dziecko porusza siê w boki
        float dotProductRight = Vector3.Dot(childRight, childMovement.normalized);
        float dotProductLeft = Vector3.Dot(-childRight, childMovement.normalized);

        float tiltAngle = 30f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        if (dotProductRight > 0.5f)
        {
            targetRotation = Quaternion.Euler(0, 0, -tiltAngle);
        }
        else if (dotProductLeft > 0.5f)
        {
            targetRotation = Quaternion.Euler(0, 0, tiltAngle);
        }

        // Interpolacja miêdzy aktualn¹ a docelow¹ rotacj¹
        transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, targetRotation, Time.deltaTime * 10f);

    }

    public void Rotate(float rotationY)
    {
        this.rotationY = rotationY;
    }




    public float GetHealth()
    {
        return health;
    }

    public void IncreaseHealth(float hp) {
        health += hp;
        HUDController.GetComponent<HUDController>().UpdateHealth(GetHealth());
    }
    public void DecreaseHealth(float hp) {
    health -= hp;
    HUDController.GetComponent<HUDController>().UpdateHealth(GetHealth());
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LvlController>().showWarunek();

        }

    }

    public void Respawn()
    {
        health = 100;
        HUDController.GetComponent<HUDController>().UpdateHealth(GetHealth());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            DecreaseHealth(10f);
            Destroy(other.gameObject); 
        }
    }

}
