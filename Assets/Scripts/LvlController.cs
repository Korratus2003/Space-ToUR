using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class LvlController : MonoBehaviour
{
    private string relativeFilePath = "Levels/";
    private string actualLevel;
    private GameObject[] Spawners;

    void Start()
    {
        actualLevel = PlayerPrefs.GetString("PlayerLevel");
        TextAsset levelFile = Resources.Load<TextAsset>(relativeFilePath + actualLevel);
        if (levelFile != null)
        {
            Spawners = InstantinateSpawners(ReadMaxLength(levelFile.text));
            StartCoroutine(ReadFile(levelFile.text));
        }
        else
        {
            Debug.LogError("Nie znaleziono pliku poziomu: " + actualLevel);
        }
        Debug.Log(actualLevel);
    }

    IEnumerator ReadFile(string fileContent)
    {
        using (StringReader sr = new StringReader(fileContent))
        {
            string line;
            int timeout = 1;

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('>');
                if (parts.Length > 1)
                {
                    string before = parts[0].Trim();
                    string after = parts[1].Trim();

                    Debug.Log("Przeciwnicy: " + before + " timeout:" + after);

                    string[] numbers = before.Split(' ');

                    foreach (string number in numbers)
                    {
                        int num = int.Parse(number);
                        Spawners[i].GetComponent<EnemySpawner>().InstantinateEnemy(num);
                        i++;
                    }
                    i = 0;
                    timeout = int.Parse(after);
                }
                yield return new WaitForSeconds(timeout);
            }
        }
    }

    int ReadMaxLength(string fileContent)
    {
        int maxLength = 0;
        using (StringReader sr = new StringReader(fileContent))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('>');
                if (parts.Length > 1)
                {
                    string before = parts[0].Trim();
                    string after = parts[1].Trim();

                    int actualLength = CountLength(before);
                    if (actualLength > maxLength)
                        maxLength = actualLength;
                }
            }
        }

        return maxLength;
    }

    int CountLength(string line)
    {
        int count = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != ' ')
                count++;
        }
        return count;
    }

    private GameObject[] InstantinateSpawners(int n)
    {
        float distance = 16f / (n + 1);
        GameObject[] spawners = new GameObject[n];

        for (int i = 0; i < n; i++)
        {
            GameObject spawner = new GameObject("EnemySpawner" + (i + 1));
            spawner.transform.position = new Vector3(((i + 1) * distance - 8f), 0, 14);
            spawner.transform.SetParent(this.transform);
            spawner.AddComponent<EnemySpawner>();
            spawners[i] = spawner;
        }

        return spawners;
    }
}
