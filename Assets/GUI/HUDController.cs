using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public TextMeshProUGUI Points;

    public void UpdateHealth(float health)
    {
        HP.text = "HP:" + health.ToString();
    }

    public void UpdatePoints(float points)
    {
        Points.text = "PUNKTY: " + points.ToString();
    }
}
