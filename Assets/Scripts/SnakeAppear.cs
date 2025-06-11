using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeAppear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SnakeSegment"))
        {
            other.GetComponent<SpriteRenderer>().enabled = true;
            other.GetComponent<Spike>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SnakeSegment"))
        {
            Destroy(other.gameObject);
        }
    }
}