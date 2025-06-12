using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeParticleCollision : MonoBehaviour
{
    public GameObject SnakeHead;
    public GameObject SnakeTail;
    public bool hitSnake;
    void Start()
    {
        SnakeHead = GameObject.Find("SnakeHead");
        SnakeTail = GameObject.Find("SnakeTail");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        if (other.gameObject == SnakeHead)
        {
            hitSnake = true;
            print("hitsnakehead");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("exitcollision");
        if (other.gameObject == SnakeTail)
        {
            hitSnake = false;
            print("exitsnaketail");
        }
    }
    void Update()
    {
        if (hitSnake)
        {
            //gameObject.GetComponent<ParticleSystem>().SetActive(true);
            //gameObject.ParticleSystem.Stop();
        }
        else
        {
            //gameObject.GetComponent<ParticleSystem>().SetActive(false);
            //gameObject.ParticleSystem.Play();
        }
    }
}