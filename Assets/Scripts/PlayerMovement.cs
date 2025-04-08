using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    public Vector2 moveDirection;
    private bool isMoving;
    private bool facingRight = true;
    private Rigidbody2D rb;
    int layerMask;
    public bool playerAlive=true;
    public GameObject SawMovementPoint;
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
        animator.SetBool("isMoving", isMoving);
        if(!isMoving&&playerAlive)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection=Vector2.up;
                isMoving=true;
                RotatePlayerToWall(moveDirection);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection=Vector2.down;
                isMoving = true;
                RotatePlayerToWall(moveDirection);
            }
            else if(Input.GetKey(KeyCode.LeftArrow))
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
                RotatePlayerToWall(moveDirection);
            }
            else if(Input.GetKey(KeyCode.RightArrow))
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
                RotatePlayerToWall(moveDirection);
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
                //GameObject sawMovementPoint=Instantiate(SawMovementPoint,transform.position,transform.rotation);
                if(manager.GetComponent<GameManager>().saw.GetComponent<Saw>().isTriggered)
                    manager.GetComponent<GameManager>().saw.GetComponent<Saw>().destinations.Enqueue(transform.position);
                //print(manager.GetComponent<GameManager>().saw.GetComponent<Saw>().destinations.Peek());
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("BouncePad"))
        {
            switch(col.gameObject.transform.eulerAngles.z)
            {
                case 0f:
                    if(moveDirection==Vector2.right)moveDirection=Vector2.up;
                    else moveDirection=-Vector2.right;
                    break;
                case 90f:
                    if(moveDirection==Vector2.right)moveDirection=Vector2.down;
                    else moveDirection=-Vector2.right;
                    break;
                case 180f:
                    if(moveDirection==Vector2.left)moveDirection=Vector2.down;
                    else moveDirection=Vector2.right;
                    break;
                case 270f:
                    if(moveDirection==Vector2.left)moveDirection=Vector2.up;
                    else moveDirection=Vector2.right;
                    break;
            }
            transform.position=(Vector2)col.gameObject.transform.position+(Vector2)moveDirection*0.2f;
            isMoving=true;
            RotatePlayerToWall(moveDirection);
        }
    }
}