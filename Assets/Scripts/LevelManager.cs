using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
[System.Serializable]
public class GameData
{
    public int FurthestLevel;
    public int[] Stars;
}

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
        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            GameData loadedGameData = JsonUtility.FromJson<GameData>(json);
            print(loadedGameData.Stars);
    
            //FurthestLevel = int.Parse(json.Substring(24));

            //print(FurthestLevel);
        }
        DontDestroyOnLoad(gameObject);
    }
}