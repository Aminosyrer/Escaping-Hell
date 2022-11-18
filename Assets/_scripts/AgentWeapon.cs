using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float desiredAngle;

    [SerializeField]
    protected WeaponRenderer weaponRenderer;

    [SerializeField]
    protected Weapon weapon;

    // awake kaldes når ens script bliver åbnet, eller hvis et objekt 
    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    // her laver vi aimweapon til player, så vore gun pointer den rigtige vej
    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3) pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    //her adjuster vi ved at flipspirte (gun),
    //og hvis man henter gun bag over hovedet så vender den vores gun og player
    protected void AdjustWeaponRendering()
    {

        if (weaponRenderer != null)
        {
            // "?" to check if its not now
            weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
            weaponRenderer.RendererBehindHead(desiredAngle < 180 && desiredAngle > 0);
        }   
    }

    // skyder
    public void Shoot()
    {
        if(weapon != null)
            weapon.TryShooying();
    }

    //stops shooting
    public void StopShooting()
    {
        if (weapon != null)
            weapon.StopShooting();
    }
}
