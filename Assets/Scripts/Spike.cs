using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spike : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player=GameObject.Find("Travelboy");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().PlayerDeath();
        }
    }
}