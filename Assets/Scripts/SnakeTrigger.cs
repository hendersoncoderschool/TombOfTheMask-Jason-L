using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var SnakeParts =FindObjectsByType<SnakeMovement>(FindObjectsSortMode.None);
            foreach(var part in SnakeParts)
            {
                if(part.id==id)
                {
                    part.active = true;
                }
            }
        }
    }
}