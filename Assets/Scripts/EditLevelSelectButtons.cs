using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditLevelSelectButtons : MonoBehaviour
{
    public LevelManager levelManager;
    public Sprite YellowStar;
    void Start()
    {
        levelManager=GameObject.Find("LevelManager").GetComponent<LevelManager>();
        foreach (Transform child in transform)
        {
            if (int.Parse(child.name.Substring(5)) <= levelManager.FurthestLevel + 1)
            {
                Image buttonImage = child.gameObject.GetComponent<Image>();
                Color color = new Color32(255, 232, 0, 255);
                buttonImage.color = color;
            }
            Transform Stars = child.Find("Stars");
            foreach (Transform star in Stars)
            {
                if (int.Parse(star.name.Substring(4)) <= levelManager.Stars[int.Parse(child.name.Substring(5))-1])
                {
                    star.gameObject.GetComponent<Image>().sprite=YellowStar;
                }
            }
        }
    }
}