using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SendToMainMenu : MonoBehaviour
{
    void Start()
    {
        SaveData();
        SceneManager.LoadScene("Main Menu");
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(this);
        print(json);
        using(StreamWriter writer=new StreamWriter(Application.dataPath+Path.AltDirectorySeparatorChar+"SaveData.json"))
        {
            writer.Write(json);
        }
    }
}