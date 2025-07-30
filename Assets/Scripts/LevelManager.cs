using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public int FurthestLevel;
    void Start()
    {
        FurthestLevel = 1;
        DontDestroyOnLoad(gameObject);
    }
}