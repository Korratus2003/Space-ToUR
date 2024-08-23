using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public GameObject Player;
    public Material BackgroundMaterial;
    public float Speed = 0.005f;

    // Update is called once per frame
    void Update()
    {
        // Ruch przeciwny do gracza
        Vector3 playerForward = Player.transform.GetChild(0).forward;
        Vector3 translatedForward = transform.InverseTransformDirection(playerForward);

        // Przeka¿ pozycjê gracza do shadera
        BackgroundMaterial.SetVector("_PlayerPos", new Vector4(translatedForward.x, translatedForward.y, 0, 0));
        BackgroundMaterial.SetFloat("_Speed", Speed);


    }
}

