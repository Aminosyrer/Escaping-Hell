using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject muzzle;

    [SerializeField]
    protected int ammo = 10;

    [SerializeField]
    protected WeaponDataSO weaponData;

    [NonSerialized]
    public WeaponDataSO mWeaponData;

    public int Ammo
    {
        get { return ammo; }
        set { 
            ammo = Mathf.Clamp(value, 0, mWeaponData.AmmoCapacity);
            ammo = value; 
        }
    }

    //ammo full
    public bool AmmoFull { get => Ammo >= mWeaponData.AmmoCapacity; }

    protected bool isShooting = false;

    [SerializeField]
    protected bool ReloadCoroutine = false;


    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    private void Start()
    {
        // gives us some scriptable object we can change
        mWeaponData = Instantiate(weaponData);
        mWeaponData.BulletData = Instantiate(weaponData.BulletData);
        Ammo = weaponData.AmmoCapacity;
    }

    public void TryShooying()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
       isShooting = false;
    }

    public void Realod(int ammo)
    {
        Ammo += ammo;
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && ReloadCoroutine == false)
        {
            if (Ammo > 0)
            {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < mWeaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (mWeaponData.AutomaticFire == false )
        {
            isShooting = false;
        }
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        ReloadCoroutine = true;
        yield return new WaitForSeconds(mWeaponData.WeaponDelay);
        ReloadCoroutine = false;
    }
     
    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = Instantiate(mWeaponData.BulletData.bulletPrefab, position, rotation);
        Debug.Log(mWeaponData.BulletData.Damage);
        bulletPrefab.GetComponent<Bullet>().BulletData = mWeaponData.BulletData;
    }

    //Quaternion represent the rotation
    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-mWeaponData.SpreadAngle, mWeaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}
