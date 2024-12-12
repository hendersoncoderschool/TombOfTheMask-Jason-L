using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DartTrap : MonoBehaviour
{
    public GameObject dart;
    public Sprite firing;
    public Sprite idle;
    void Start()
    {
        StartCoroutine (shoot());
    }
    IEnumerator shoot()
    {
        while(true)
        {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite=firing;
        GameObject projectile = Instantiate(dart,transform.position+-transform.right,transform.rotation);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite=idle;
        }
    }
}