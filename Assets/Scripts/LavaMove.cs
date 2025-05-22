using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LavaMove : MonoBehaviour
{
    public float speed;
    private GameObject cam;
    Renderer rend;
    public Color firstColor;
    public Color secondColor;
    void Start()
    {
        cam=GameObject.Find("Main Camera");
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }
    void Update()
    {
        transform.position=new Vector2(cam.transform.position.x,transform.position.y+speed*Time.deltaTime);
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            rend.material.SetColor("_Color",firstColor);
            yield return new WaitForSeconds(0.12f);
            rend.material.SetColor("_Color",secondColor);
            yield return new WaitForSeconds(0.12f);
        }
    }
}