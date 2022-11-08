using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int Health { get; set; }

    [field: SerializeField]
    public int MaxHealth { get; set; }

    private bool dead = false;

    [SerializeField]
    private bool invulnerable = false;

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    public void Awake()
    {
        Health = MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead && !invulnerable)
        {
            Health -= damage;
            invulnerable = true;
            Invoke("MakeVulnerable", 0.5f);
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }
    }

    private void MakeVulnerable()
    {
        invulnerable = false;
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

}
