using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DartMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-Vector2.right*Time.deltaTime*20f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer==3)
        {
            Destroy(gameObject);
        }
    }
}