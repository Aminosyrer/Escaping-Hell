using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HzardDamage : MonoBehaviour
{
    public int damage;

    public void DoDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0);
        foreach(var i in colliders)
        {
            if (i.GetComponent<IHittable>() != null)
            {
                i.GetComponent<IHittable>().GetHit(damage, gameObject);
            }
        }
    }
}
