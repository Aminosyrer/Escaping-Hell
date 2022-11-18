using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dette script er for vores weapons og hvilker properties vi har valgt at den skal have.
[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    //vi refferer til vores BulletDataSO
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }

    // antal ammo
    [field: SerializeField]
    [field: Range(0,500)]
    public int AmmoCapacity { get;  set; } = 500;

    //dette viser at den gun vi bruger skyder automatisk
    [field: SerializeField]
    public bool AutomaticFire { get;  set; } = false;

    // dette viser weapondelay
    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = .1f;

    //dette viser om vore gun spreder bullet eller er det i en lige linje
    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5;

    // kan pistolen skyde flere end 1 bullet af gangen? nej den er false
    [SerializeField]
    public bool multiBulletShoot = false;

    //det er en funktion der tælller antal bullet
    [SerializeField]
    [Range(1,10)]
    public int bulletCount = 1;

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShoot)
        {
            return bulletCount;
        }
        return 1;
    }
}
