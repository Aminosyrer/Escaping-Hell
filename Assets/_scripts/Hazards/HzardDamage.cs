using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HzardDamage : MonoBehaviour
{
    public void DoDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0);
        Debug.Log(colliders.Length);
        foreach(var i in colliders)
        {
            Destroy(i.gameObject);
        }
    }
}
