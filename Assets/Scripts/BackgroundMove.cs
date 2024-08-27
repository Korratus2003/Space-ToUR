using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BackgroundMove : MonoBehaviour
{
    public GameObject Player;
    public Material BackgroundMaterial;
    private Vector2 backgroundPosition = new Vector2(0,0);
    public string actualLevel = "Default";
    public float speed = 0.02f;

    private void Start()
    {
        Texture2D backgroundTexture = Resources.Load<Texture2D>(($"Backgrounds/Background{actualLevel}"));
        if (backgroundTexture != null)
            BackgroundMaterial.SetTexture("_Background", backgroundTexture);
    }

    // Update is called once per frame
    void Update()
    {
        // Ruch przeciwny do gracza
        Vector3 playerForward = Player.transform.GetChild(0).forward;
        Vector3 translatedForward = transform.InverseTransformDirection(playerForward);

        // Przeka¿ pozycjê gracza do shadera

        backgroundPosition = new Vector2 (backgroundPosition.x + (translatedForward.x * Time.deltaTime * speed),backgroundPosition.y + (translatedForward.y * Time.deltaTime * speed));


        BackgroundMaterial.SetVector("_PlayerForward", backgroundPosition);


    }
}

