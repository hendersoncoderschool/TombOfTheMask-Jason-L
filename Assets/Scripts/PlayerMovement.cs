using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    private Vector2 moveDirection;
    private bool isMoving;
    private bool facingRight = true;
    private Rigidbody2D rb;
    int layerMask;
    public bool playerAlive=true;
    GameObject manager;
    void Start()
    {
        manager=GameObject.Find("GameManager");
        rb=GetComponent<Rigidbody2D>();
        layerMask = LayerMask.GetMask("WallLayer");
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        if(!isMoving&&playerAlive)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDirection=Vector2.up;
                isMoving=true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDirection=Vector2.down;
                isMoving = true;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDirection=Vector2.left;
                isMoving=true;
                if (facingRight)
                {
                    facingRight = !facingRight;
                    Vector2 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDirection=Vector2.right;
                isMoving=true;
                if(!facingRight)
                {
                    facingRight = !facingRight;
                    Vector2 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if(isMoving)
        {
            rb.velocity=moveDirection*moveSpeed*Time.fixedDeltaTime;
            RaycastHit2D hit=Physics2D.Raycast(transform.position,moveDirection,0.6f,layerMask);
            if(hit.collider!=null)
            {
                rb.velocity=Vector2.zero;
                transform.position=hit.point-(Vector2)moveDirection*0.5f;
                isMoving=false;
                RotatePlayerToWall(moveDirection);
            }
        }
    }
    void RotatePlayerToWall(Vector2 moveDirection)
    {
        float angle = 0f;
        if (moveDirection == Vector2.up)
        {
            angle = 180f;
        }
        else if (moveDirection == Vector2.down)
        {
            angle = 0f;
        }
        else if (moveDirection == Vector2.left)
        {
            angle = -90f;
        }
        else if (moveDirection == Vector2.right)
        {
            angle = 90f;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void PlayerDeath()
    {
        animator.SetTrigger("Explode");
        isMoving=false;
        rb.velocity*=0f;
        playerAlive=false;
        StartCoroutine(resetScene());
    }
    IEnumerator resetScene()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(manager.GetComponent<GameManager>().currentScene);
    }
}