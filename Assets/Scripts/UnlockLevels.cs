using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockLevels : MonoBehaviour
{
    public LevelManager levelManager;
    void Start()
    {
        levelManager=GameObject.Find("LevelManager").GetComponent<LevelManager>();
        foreach (Transform child in transform)
        {
            if(int.Parse(child.name.Substring(5))<=levelManager.FurthestLevel+1)
            {
                Image buttonImage=child.gameObject.GetComponent<Image>();
                Color color= new Color32(255,232,0,255);
            }
        }
    }
}