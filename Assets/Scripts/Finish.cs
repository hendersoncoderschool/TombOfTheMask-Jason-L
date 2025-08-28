using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Finish : MonoBehaviour
{
    public string scenename;
    private string saveFile;
    private LevelManager levelManager;
    private GameManager gameManager;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        saveFile = Path.Combine(Application.persistentDataPath, "save.json");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            int levelNum=int.Parse(GameObject.Find("GameManager").GetComponent<GameManager>().currentScene.Substring(5));
            levelManager.FurthestLevel = Mathf.Max(levelNum,levelManager.FurthestLevel);
            levelManager.Stars[levelNum - 1] = Mathf.Max(gameManager.collectedStars,levelManager.Stars[levelNum-1]);
            SaveGame();
            SceneManager.LoadScene(scenename);
        }
    }
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(levelManager, true);
        File.WriteAllText(saveFile, json);
        Debug.Log("Game Saved to: " + saveFile);
    }
}