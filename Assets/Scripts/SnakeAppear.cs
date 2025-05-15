using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeAppear : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("SnakeSegment"))
        {
            print(other.name);
            other.GetComponent<SpriteRenderer>().enabled = true;
            other.GetComponent<Spike>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("Exit");
        if (other.CompareTag("SnakeSegment"))
        {
            Destroy(other);
        }
    }
}