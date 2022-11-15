using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : PowerUp
{
    [Range(0, 100)]
    public int PercentAmmo;

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var weapon = collision.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                int x = Mathf.CeilToInt(weapon.mWeaponData.AmmoCapacity / (PercentAmmo * 1f));
                weapon.Realod(x);
            }
            Destroy(gameObject);
        }
    }
}
