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
    private Player Player;

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

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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


                    string[] IDs = before.Split(' ');

                    foreach (string ID in IDs)
                    {
                        int num;

                        if (int.TryParse(ID, out num)) { 
                        Spawners[i].GetComponent<EnemySpawner>().InstantiateEnemy(num); 
                        }
                        else
                        {
                        Debug.Log(ID);
                        }
                        
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
            GameObject spawner = new GameObject("Spawner" + (i + 1));
            spawner.transform.SetParent(this.transform);
            spawner.transform.localPosition = new Vector3(((i + 1) * distance - 8f), 0, 14);
            spawner.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
            spawner.AddComponent<EnemySpawner>();
            spawners[i] = spawner;
        }

        return spawners;
    }

    public void Rotate(Quaternion rotation)
    {
        this.transform.rotation = rotation;
        Player.transform.rotation = rotation;
    }
}
