using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFireRate : PowerUp
{
    [Range(0, 100)]
    public int PercentIncrease;

    private void Start()
    {
        gameObject.GetComponentInChildren<TMPro.TextMeshPro>().SetText($"+{PercentIncrease}% Fire rate");
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var weapon = collision.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.mWeaponData.WeaponDelay *= (100f-PercentIncrease)/100f;
            }
            Destroy(gameObject);
        }
    }
}
