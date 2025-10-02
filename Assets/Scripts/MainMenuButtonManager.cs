using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{
    public LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    public void LoadFurthestLevel()
    {
        SceneManager.LoadScene("Level" + (Mathf.Min(10,levelManager.FurthestLevel+1)).ToString());
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}