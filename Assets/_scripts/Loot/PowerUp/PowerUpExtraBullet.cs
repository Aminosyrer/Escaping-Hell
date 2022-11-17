using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpExtraBullet : PowerUp
{
    public int Increase;

    private void Start()
    {
        // Must be plural wont have any +2 bullet
        string text = Increase > 1 ? $"+{Increase} Bullets" : $"+{Increase} Bullet";
        gameObject.GetComponentInChildren<TextMeshPro>().SetText(text);
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var weapon = collision.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.mWeaponData.multiBulletShoot = true;
                weapon.mWeaponData.bulletCount += Increase;
            }
            Destroy(gameObject);
        }
    }
}
