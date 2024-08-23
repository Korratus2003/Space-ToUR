using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public LvlHolder LvlHolder;
    public GameObject Background;

    public void klyk()
    {
        Debug.Log("klyk");
    }

    public void increase()
    {
        LvlHolder.increase();
    }

    public void decrease()
    {
        LvlHolder.decrease();
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("PlayerLevel", LvlHolder.GetLevel());
        SceneManager.LoadScene("lvl");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
