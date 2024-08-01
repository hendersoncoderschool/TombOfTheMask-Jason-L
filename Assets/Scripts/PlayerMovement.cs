using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=5f;
    private Vector2 moveDirection;
    private bool isMoving;
    private Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!isMoving)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
            moveDirection=Vector2.up;
            isMoving=true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
            moveDirection=Vector2.down;
            isMoving=true;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
            moveDirection=Vector2.left;
            isMoving=true;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
            moveDirection=Vector2.right;
            isMoving=true;
            }
        }
    }
    void FixedUpdate()
    {
        if(isMoving)
        {
            rb.velocity=moveDirection*moveSpeed;
            RaycastHit2D hit=Physics2D.Raycast(transform.position,moveDirection,0.1f);
            if(hit.collider!=null)
            {
                rb.velocity=Vector2.zero;
                transform.position=hit.point-(Vector2)moveDirection*0.5f;
                isMoving=false;
                //RotatePlayerToWall(moveDirection);
            }
        }
    }
}