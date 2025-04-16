using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Saw : MonoBehaviour
{
    public Queue<Vector2> destinations;
    public bool isTriggered;
    public float speed;
    public GameObject player;
    void Start()
    {
        destinations=new Queue<Vector2>();
    }
    void Update()
    {
        if(isTriggered)
        {
            if(destinations.Count==0)
            {
                transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
            }
            else
            {
                transform.position=Vector2.MoveTowards(transform.position,destinations.Peek(),speed*Time.deltaTime);
                if(Vector2.Distance(transform.position,destinations.Peek())<0.01f)
                {
                    destinations.Dequeue();
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Toggleable Wall"))
        {
            Destroy(gameObject);
        }
    }
}