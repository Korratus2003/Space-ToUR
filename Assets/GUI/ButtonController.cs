using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public LvlHolder LvlHolder;

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
}
