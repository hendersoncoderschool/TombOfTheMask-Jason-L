using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectButtonManager : MonoBehaviour
{
    public LevelManager levelManager;
    void Start()
    {
        levelManager=GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    public void LoadLevel(int levelnumber)
    {
        if(levelManager.FurthestLevel+1>=levelnumber)
        {
            SceneManager.LoadScene("Level"+levelnumber.ToString());
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
