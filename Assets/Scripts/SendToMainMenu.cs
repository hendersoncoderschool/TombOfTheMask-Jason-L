using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SendToMainMenu : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Main Menu");
    }
}