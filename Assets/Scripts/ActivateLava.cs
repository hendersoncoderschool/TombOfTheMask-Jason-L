using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActivateLava : MonoBehaviour
{
    private PlayerMovement player;
    void Start()
    {
        player=GameObject.Find("Travelboy").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if(player.moveDirection!=new Vector2()&&player.moveDirection!=Vector2.down)
        {
            GetComponent<LavaMove>().enabled=true;
            enabled=false;
        }
    }
}