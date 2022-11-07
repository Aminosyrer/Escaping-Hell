using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMaxHealth : PowerUp
{
    public int Increase;

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            //if this is ever null, i will stab a bitch
            if (player != null)
            {
                player.Health += Increase;
                player.MaxHealth = Increase;
            }
            Destroy(gameObject);
        }
    }
}
