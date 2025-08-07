using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{
    // public void LoadFurthestLevel()
    // {
        
    // }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}