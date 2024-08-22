using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlHolder : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private int actualLevel = 1;
    private int txtFileCount;

    void Start()
    {
        // £adowanie wszystkich plików tekstowych z folderu Resources/Levels
        TextAsset[] textFiles = Resources.LoadAll<TextAsset>("Levels");
        txtFileCount = textFiles.Length;
        Debug.Log($"Liczba plików .txt w folderze: {txtFileCount}");

        textMeshPro = this.GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI nie zosta³ znaleziony!");
        }
        PrintLevel();
    }

    public void increase()
    {
        if (actualLevel < txtFileCount)
            actualLevel++;
        Debug.Log(actualLevel);
        PrintLevel();
    }

    public void decrease()
    {
        if (actualLevel > 1)
            actualLevel--;
        Debug.Log(actualLevel);
        PrintLevel();
    }

    private void PrintLevel()
    {
        textMeshPro.text = "lvl " + actualLevel.ToString() + "/" + txtFileCount.ToString();
    }

    public string GetLevel()
    {
        return actualLevel.ToString();
    }
}
