using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeParticleCollision : MonoBehaviour
{
    public bool hitSnake;
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "SnakeHead")
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "SnakeTail")
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}