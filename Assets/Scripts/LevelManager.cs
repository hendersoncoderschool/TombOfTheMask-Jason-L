using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
public class LevelManager : MonoBehaviour
{
    public int FurthestLevel;
    public int[] Stars;
    void Start()
    {
        Stars = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Stars[i] = 0;
        }
        FurthestLevel = 0;

        string saveFile = Path.Combine(Application.persistentDataPath, "save.json");
        if (saveFile.Exists(saveFile))
        {
            string json = saveFile.ReadAllText(saveFile);
            
        }
        DontDestroyOnLoad(gameObject);
    }
}