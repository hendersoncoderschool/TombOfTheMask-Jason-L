using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SawTrigger : MonoBehaviour
{
    public Saw saw;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            saw.isTriggered=true;
        }
    }
}