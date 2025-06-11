using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollide : MonoBehaviour
{
    public GameObject SnakeFirstSegment;
    public GameObject SnakeTail;
    public GameObject ParticleEffect;
    public bool hitSnake;
    void Start()
    {
        SnakeFirstSegment = GameObject.Find("SnakeBody (1)");
        SnakeTail = GameObject.Find("SnakeTail");
        ParticleEffect = GameObject.Find("WallBreakEffect");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == SnakeFirstSegment)
        {
            hitSnake=true;
            print("enter");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject==SnakeTail)
        {
            hitSnake = false;
            print("exit");
        }
    }
    private void Update()
    {
        if(hitSnake)
        {
            ParticleEffect.SetActive(true);
        }
        else
        {
            ParticleEffect.SetActive(false);
        }
    }
}