using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpBulletDamage : PowerUp
{
    public int Increase;

    private void Start()
    {
        gameObject.GetComponentInChildren<TextMeshPro>().SetText($"+{Increase} Damage");
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var weapon = collision.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.mWeaponData.BulletData.Damage += Increase;
            }
            Destroy(gameObject);
        }
    }
}
