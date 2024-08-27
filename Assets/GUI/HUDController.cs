using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HUDController : MonoBehaviour
{
    public GameObject HP;
    public TextMeshProUGUI Points;
    private Image HPColor;


    private void Start()
    {
        HPColor = HP.GetComponent<UnityEngine.UI.Image>();
    }

    public void UpdateHealth(float health)
    {
        HP.transform.localScale = new Vector3(health*0.01f,1,1);
        SetColor(new Color(1-((100-health)*0.005f),0,0,1));
    }

    public void UpdatePoints(float points)
    {
        Points.text = "PT: " + points.ToString();
    }

    public void SetColor(Color color)
    {
        HPColor.color = color;
    }
}
