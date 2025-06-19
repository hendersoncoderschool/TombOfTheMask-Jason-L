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
        GetComponent<ParticleSystem>().Stop();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        if (other.gameObject == SnakeHead)
        {
            //hitSnake = true;
            GetComponent<ParticleSystem>().Play();
            print("hitsnakehead");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("exitcollision");
        if (other.gameObject == SnakeTail)
        {
            //hitSnake = false;
            GetComponent<ParticleSystem>().Stop();
            print("exitsnaketail");
        }
    }
    void Update()
    {
        if (hitSnake)
        {
            //gameObject.GetComponent<ParticleSystem>().SetActive(true);
            //GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            //gameObject.GetComponent<ParticleSystem>().SetActive(false);
            //GetComponent<ParticleSystem>().Play();
        }
    }
}