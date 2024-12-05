using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DartTrap : MonoBehaviour
{
    public GameObject dart;
    void Start()
    {
        InvokeRepeating("shoot",0f,1.2f);
    }
    void shoot()
    {
        GameObject projectile = Instantiate(dart,transform.position+-transform.right,Quaternion.identity);
        projectile.transform.Rotate(transform.forward * 90f);
    }
}