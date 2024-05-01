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
    public float smoothnessFactor = 6f;
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
        // Ustawienie limitów, aby gracz nie wylecia³ poza kamerê
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(Player.transform.localPosition.x, -8.2f, 8.2f),
            Mathf.Clamp(Player.transform.localPosition.y, -4.3f, 4.3f),
            Player.transform.localPosition.z
        );
        Player.transform.localPosition = clampedPosition;

        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * speed * Time.deltaTime;

        float targetZRotation = Mathf.Clamp(-moveHorizontal * 1000 * Time.deltaTime, -40f, 40f);
        Quaternion targetRotation = Quaternion.Euler(-90f, 90f, -90+targetZRotation);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smoothnessFactor);


    }
}
