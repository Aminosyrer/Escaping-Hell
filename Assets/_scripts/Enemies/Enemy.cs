using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public EnemyAttack enemyAttack { get; set; }

    [Range(0, 1)]
    public float TimeToDie;

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake()
    {
        if(enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }
    }


    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(dead == false)
        {
            Debug.Log("aw");
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();
                StartCoroutine(WaitToDie());
            }
        }
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(TimeToDie);
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if(dead == false)
        {
            enemyAttack.Attack(EnemyData.Damage);
        }
    }

}
