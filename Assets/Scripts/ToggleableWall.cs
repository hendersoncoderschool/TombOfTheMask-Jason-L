using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableWall : MonoBehaviour
{
    public Sprite activeWall;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            gameObject.layer=LayerMask.NameToLayer("WallLayer");
            GetComponent<SpriteRenderer>().sprite = activeWall;
        }
    }
}