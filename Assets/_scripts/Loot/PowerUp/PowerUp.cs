using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour
{
    public BoxCollider2D Collider;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        Collider.enabled = false;
        Collider.isTrigger = false;
        //waits just a moment so player can see what powerup just dropped
        Invoke("Enable", 1);
    }

    private void Enable()
    {
        Collider.enabled = true;
        Collider.isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
