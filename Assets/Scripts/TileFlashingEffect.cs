using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileFlashingEffect : MonoBehaviour
{
    SpriteRenderer rend;
    public Color firstColor;
    public Color secondColor;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        for (int i = 0; i < 3; i++)
        {
            print("flash");
            rend.color = firstColor;
            //rend.material.SetColor("_Color", firstColor);
            yield return new WaitForSeconds(0.12f);
            rend.color = secondColor;
            //rend.material.SetColor("_Color", secondColor);
            yield return new WaitForSeconds(0.12f);
        }
    }
}