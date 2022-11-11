using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpSpeed : PowerUp
{
    [Range(0, 100)]
    public int PercentIncrease;

    private void Start()
    {
        gameObject.GetComponentInChildren<TextMeshPro>().SetText($"+{PercentIncrease}% Speed");
    }

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AgentMovement agentMovement = collision.GetComponent<AgentMovement>();
            //if this is ever null, i will stab a bitch
            if (agentMovement != null)
            {
                agentMovement.CurrentMaxSpeed *= (100f+PercentIncrease)/100f;
            }
            Destroy(gameObject);
        }
    }
}
