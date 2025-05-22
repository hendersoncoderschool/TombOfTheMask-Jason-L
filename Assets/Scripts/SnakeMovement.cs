using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int id;
    public float speed;
    public bool active;
    void Start()
    {
        active = false;
    }
    void Update()
    {
        if (active)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}