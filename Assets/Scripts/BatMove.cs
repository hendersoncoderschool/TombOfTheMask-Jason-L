using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatMove : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public Transform target;
    public float speed;
    private bool moving;
    void Start()
    {
        transform.position=new Vector3(point1.transform.position.x,point1.transform.position.y,transform.position.z);
        moving=true;
    }
    void Update()
    {
        if(moving)
        {
            transform.position=Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
            if(Vector2.Distance(transform.position,target.position)<0.1f)
            {
                StartCoroutine(SwitchTarget());
            }
        }
    }
    IEnumerator SwitchTarget()
    {
        if (target==point1.transform)
        {
            target=point2.transform;
        }
        else
        {
            target=point1.transform;
        }
        moving=false;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        yield return new WaitForSeconds(0.7f);
        moving=true;
    }
}