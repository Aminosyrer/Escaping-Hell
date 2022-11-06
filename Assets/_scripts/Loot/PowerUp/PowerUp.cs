using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PowerUp : MonoBehaviour
{
    public BoxCollider2D Collider;
    public Rigidbody2D Rigidbody;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = new Vector2((Random.value *2) - 1, (Random.value * 2) - 1);
        //waits just a moment so player can see what powerup just dropped
        Invoke("Enable", 1);
    }

    private void Enable()
    {
        gameObject.layer = 0;
        Rigidbody.velocity = Vector2.zero;
        Collider.isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
