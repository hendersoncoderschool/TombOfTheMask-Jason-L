using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PufferTimer : MonoBehaviour
{
    bool pufferActivated=false;
    public float cooldown;
    public GameObject BigPuffer;
    public GameObject SmallPuffer;
    void Start()
    {
        BigPuffer=transform.Find("BigPuffer").gameObject;
        SmallPuffer=transform.Find("SmallPuffer").gameObject;
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(cooldown);
            if(pufferActivated)
            {
                BigPuffer.SetActive(false);
                SmallPuffer.SetActive(true);
                pufferActivated=false;
            }
            else
            {
                BigPuffer.SetActive(true);
                SmallPuffer.SetActive(false);
                pufferActivated=true;
            }
        }
    }
}