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
    public GameObject Armor;
    public TextMeshProUGUI Points;
    private Image HPColor;
    private Image ArmorColor;


    private void Start()
    {
        HPColor = HP.GetComponent<UnityEngine.UI.Image>();
        ArmorColor = Armor.GetComponent<UnityEngine.UI.Image>();
    }

    public void UpdateHealth(float health)
    {
        if (health <= 100) {
            HP.transform.localScale = new Vector3(health * 0.01f, 1, 1);
            SetColorHP(new Color(1 - ((100 - health) * 0.005f), 0, 0, 1)); 
        }
        if (health > 100)
        {
            Armor.transform.localScale = new Vector3((health - 100) * 0.01f, 1.1f, 1);
            SetColorArmor(new Color(0, 0, 1 - ((200 - health) * 0.005f), 1));
        }

        
    }

    public void UpdatePoints(float points)
    {
        Points.text = "PT: " + points.ToString();
    }

    public void SetColorHP(Color color)
    {
        HPColor.color = color;
    }

    public void SetColorArmor(Color color)
    {
        ArmorColor.color = color;
    }
}
