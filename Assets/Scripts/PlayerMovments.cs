using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovments : MonoBehaviour
{
    private GameObject Player;
    public Vector3 respPosition;
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //ustawienie playera na respie
        Player.transform.localPosition = respPosition;
       
    }

 
    private void FixedUpdate()
    {
        Movment();

    }

    private void Movment()
    {
        //ustawienie limitów ¿eby gracz nie wylecia³ poza kamere
        if (Player.transform.localPosition.x < -8.2f) Player.transform.localPosition = new Vector3(-8.2f, Player.transform.localPosition.y, Player.transform.localPosition.z);
        if (Player.transform.localPosition.x > 8.2f) Player.transform.localPosition = new Vector3(8.2f, Player.transform.localPosition.y, Player.transform.localPosition.z);
        if (Player.transform.localPosition.y < -4.3f) Player.transform.localPosition = new Vector3(Player.transform.localPosition.x, -4.3f, Player.transform.localPosition.z);
        if (Player.transform.localPosition.y > 4.3f) Player.transform.localPosition = new Vector3(Player.transform.localPosition.x, 4.3f, Player.transform.localPosition.z);


        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.position += movement * speed * Time.deltaTime;

    }
}
