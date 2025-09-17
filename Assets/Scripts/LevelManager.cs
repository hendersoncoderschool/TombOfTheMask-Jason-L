using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
using System.Runtime.Serialization;

[System.Serializable]

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
            var dict = Json.Deserialize(json) as Dictionary<string, object>;
            long result = (long)dict["FurthestLevel"];
            FurthestLevel = (int)result;
            List<object> tmp = (List<object>)dict["Stars"];
            for (int i=0; i<10; i++)
            {
                long num = (long)tmp[i];
                Stars[i] = (int)num;
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}