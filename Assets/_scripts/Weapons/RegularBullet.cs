using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidBody2D;

    public override BulletDataSO BulletData 
    { 
        get => base.BulletData; 
        set
        {
            base.BulletData = value;
            rigidBody2D = GetComponent<Rigidbody2D>();
            rigidBody2D.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if(rigidBody2D != null && BulletData != null)
        {
            rigidBody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);   
        }           
    }

    // her laver vi koden så hvergang vi skyder en bullet og den rammer en "obstacle"
    // så vil bullet under "hierarchy" ikke blive stablet op men den forsvinder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
        }
        else if(collision.GetComponent<IHittable>() != null)
        {
            HitEnemy(collision);
        }
        Destroy(gameObject);
    }

    //dette er det samme, men denne gang er det collider med enemy
    private void HitEnemy(Collider2D collider)
    {
        collider.GetComponent<IHittable>().GetHit(bulletData.Damage, gameObject);
    }

    //her tjekker vi med en Debug.Log hvis man rammer "obstacle" forsvinder den så?
    private void HitObstacle()
    {
        Debug.Log("Hitting Obstacle");
    }
}
