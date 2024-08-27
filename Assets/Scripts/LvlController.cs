using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class LvlController : MonoBehaviour
{
    private string relativeFilePath = "Levels/";
    private string actualLevel;
    private Coroutine FileReadCoroutine;
    private GameObject[] Spawners;
    private Player Player;
    private float points = 0;


    public GameObject Background;
    public GameObject PauseMenu;
    public GameObject HUDController;

    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        actualLevel = PlayerPrefs.GetString("PlayerLevel");
        TextAsset levelFile = Resources.Load<TextAsset>(relativeFilePath + "lvl"+actualLevel);
        if (levelFile != null)
        {
            Spawners = InstantinateSpawners(ReadMaxLength(levelFile.text));
            FileReadCoroutine = StartCoroutine(ReadLevel(levelFile.text));
        }
        else
        {
            Debug.LogError("Nie znaleziono pliku poziomu: " + actualLevel);
        }
        Background.transform.GetChild(0).GetComponent<BackgroundMove>().actualLevel = actualLevel;

        HUDController.GetComponent<HUDController>().UpdatePoints(points);

    }

    IEnumerator ReadLevel(string fileContent)
    {
        using (StringReader sr = new StringReader(fileContent))
        {
            string line;
            int timeout = 1;

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('>');

                if (parts.Length == 2)
                {
                    
                    string before = parts[0].Trim();
                    string after = parts[1].Trim();

                    // Obs³uga przypadku linii zaczynaj¹cej siê od `!`
                    if (before.StartsWith('!'))
                    {
                        string rotateValueString = before.Substring(1); // Pobranie wartoœci po `!`
                        int rotateValue;

                        if (int.TryParse(rotateValueString, out rotateValue))
                        {
                            Rotate(rotateValue);
                        }

                        // Sprawdzenie timeoutu po `>`
                        if (!int.TryParse(after, out timeout))
                        {
                            timeout = 1;
                        }
                    }
                    else
                    {
                        string[] IDs = before.Split(' ');

                        foreach (string ID in IDs)
                        {
                            if (string.IsNullOrWhiteSpace(ID)) continue;  // Pomiñ puste ID

                            int num;
                            if (int.TryParse(ID, out num))
                            {
                                Spawners[i].GetComponent<Spawner>().InstantiateEnemy(num);
                            }
                            else
                            {
                                switch (ID.ToUpper().ToCharArray()[0])
                                {
                                    case 'N':
                                        Debug.Log("N to bêdzie umowne nic");
                                        break;
                                    case 'H':
                                        Spawners[i].GetComponent<Spawner>().InstantiateHealth();
                                        break;
                                    default:
                                        Debug.Log("Niezanana litera");
                                        break;
                                }
                            }

                            i++;
                        }
                        i = 0;

                        
                    }
                    if (!int.TryParse(after, out timeout))
                    {
                        StopCoroutine(FileReadCoroutine);
                    }
                }
                else if (parts.Length == 1 && !string.IsNullOrWhiteSpace(parts[0]))
                {
                    // Obs³uga przypadku, gdy jest tylko jeden element
                    if (!int.TryParse(parts[0].Trim(), out timeout))
                    {
                        StopCoroutine(FileReadCoroutine);
                    }
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
            spawner.AddComponent<Spawner>();
            spawners[i] = spawner;
        }

        return spawners;
    }

    public void Rotate(float rotationY)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
        Player.GetComponent<Player>().Rotate(rotationY);
        
    }


    public void showWarunek()
    {
        PauseMenu.transform.GetChild(1).gameObject.SetActive(true);
    }

    public float GetPoints()
    {
        return points;
    }

    public void AddPoints(float points)
    {
        this.points += points;
        HUDController.GetComponent<HUDController>().UpdatePoints(points);
    }

    public void SetPoints(float points)
    {
        this.points = points;
        HUDController.GetComponent<HUDController>().UpdatePoints(points);
    }

}
