using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int startHealth;

    public event Action OnDeadEvent;
    private int currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int reduceHealth)
    {
        currentHealth -= reduceHealth;
        if (currentHealth <= 0)
            OnDeadEvent?.Invoke();
    }

    public void SetStartHealth(int health)
    {
        startHealth = health;
        currentHealth = health;
    }
}
