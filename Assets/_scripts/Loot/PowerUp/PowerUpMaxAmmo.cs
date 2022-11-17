using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMaxAmmo : PowerUp
{
    [Range(0, 100)]
    public int PercentIncrease;

    private void Start()
    {
        gameObject.GetComponentInChildren<TMPro.TextMeshPro>().SetText($"+{PercentIncrease}% max ammo");
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var weapon = collision.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.mWeaponData.AmmoCapacity = Mathf.CeilToInt(((100f + PercentIncrease) / 100f) + weapon.mWeaponData.AmmoCapacity);
            }
            Destroy(gameObject);
        }
    }
}
