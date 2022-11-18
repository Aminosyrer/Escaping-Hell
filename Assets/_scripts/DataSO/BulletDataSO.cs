using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// herinde gemmer vi vore bullet data
[CreateAssetMenu(menuName = "Weapons/BulletData")]
public class BulletDataSO : ScriptableObject
{
    //bullet prefab
    [field: SerializeField]
    public GameObject bulletPrefab { get; set; }

    //hastigheden for vullet
    [field: SerializeField]
    [field: Range(1, 100)]
    public float BulletSpeed { get; internal set; } = 1;

    //antal damage
    [field: SerializeField]
    [field: Range(1, 10)]
    public int Damage { get; set; } = 1;


    [field: SerializeField]
    [field: Range(0, 100)]
    public float Friction { get; internal set; } = 0;

    // man kan vælge eller vælge-fra, hvis ens bullet skal bounce hvis den rammer en væg
    [field: SerializeField]
    public bool Bounce { get; set; } = false;

    //en funktion der gør vores bullet ikke går gennem væggen
    [field: SerializeField]
    public bool GoThroughHittable { get; set; } = false;

    [field: SerializeField]
    public bool IsRayCast { get; set; } = false;


    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }

    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }

    //hvis der skal være knockbackpower når man skyder  så kan dette tændes, 
    [field: SerializeField]
    [field: Range(1, 20)]
    public float KnockBackPower { get; set; } = 5;

    // hvis der er delay på knockback så hjælper denne property med at formindske dette
    [field: SerializeField]
    [field: Range(0.01f, 1f)]
    public float KnockBackDelay { get; set; } = 0.1f;
}
