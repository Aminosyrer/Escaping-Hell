using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int Health { get; set; }

    [field: SerializeField]
    public int MaxHealth { get; set; }

    [Range(0, 2)]
    public float InvulnerableTime;

    private bool dead = false;

    [SerializeField]
    private bool invulnerable = false;

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    // first int = health, second int = maxhealth
    [field: SerializeField]
    public UnityEvent<int, int> OnHealthChange;

    public void Awake()
    {
        Health = MaxHealth;
        OnHealthChange?.Invoke(Health, MaxHealth);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead && !invulnerable)
        {
            Health -= damage;
            invulnerable = true;
            Invoke("MakeVulnerable", InvulnerableTime);
            OnGetHit?.Invoke();
            OnHealthChange?.Invoke(Health, MaxHealth);
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }
    }

    public  void Heal(int increase, bool BoostMax = false)
    {
        Health += increase;
        if (BoostMax) MaxHealth += increase;
        OnHealthChange?.Invoke(Health, MaxHealth);
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
