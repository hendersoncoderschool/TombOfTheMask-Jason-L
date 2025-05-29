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
            var tiles = FindObjectsByType<TileFlashingEffect>(FindObjectsSortMode.None);
            foreach (var tile in tiles)
            {
                if(tile.id==id)
                {
                    tile.StartFlash();
                }
            }
            Destroy(gameObject);
        }
    }
}