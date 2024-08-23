using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Player;

    public GameObject Warunek;
    public void ExitToMenu()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1.0f;
    }

    public void StayAndPlay()
    {
        //jakaœ logika
        
        Warunek.SetActive(false);
        Player.SetActive(true);
        Player.GetComponent<Player>().Respawn();
        Time.timeScale = 1.0f;

    }
}
