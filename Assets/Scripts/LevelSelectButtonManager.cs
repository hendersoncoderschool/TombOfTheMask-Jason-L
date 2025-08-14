using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectButtonManager : MonoBehaviour
{
    public void LoadLevel(int levelnumber)
    {
        SceneManager.LoadScene("Level"+levelnumber.ToString());
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
