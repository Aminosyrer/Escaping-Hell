using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUp
{
    [Range(1,2)]
    public float Increase;

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AgentMovement agentMovement = collision.GetComponent<AgentMovement>();
            if (agentMovement != null)
            {
                agentMovement.CurrentMaxSpeed *= Increase;
            }
        }
        Destroy(gameObject);
    }
}
