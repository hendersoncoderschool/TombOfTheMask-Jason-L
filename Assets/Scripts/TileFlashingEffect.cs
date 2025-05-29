using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileFlashingEffect : MonoBehaviour
{
    SpriteRenderer rend;
    public Color firstColor;
    public Color secondColor;
    public int id;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    public void StartFlash()
    {
        StartCoroutine(ChangeColor());
    }
    public IEnumerator ChangeColor()
    {
        for (int i = 0; i < 3; i++)
        {
            print("flash");
            rend.color = firstColor;
            yield return new WaitForSeconds(0.15f);
            rend.color = secondColor;
            yield return new WaitForSeconds(0.15f);
        }
        rend.color = firstColor;
        var SnakeParts = FindObjectsByType<SnakeMovement>(FindObjectsSortMode.None);
        foreach (var part in SnakeParts)
        {
            if (part.id == id)
            {
                part.active = true;
            }
        }
    }
}