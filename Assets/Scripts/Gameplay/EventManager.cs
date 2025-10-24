using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event Action OnPlayerDead;
    public event Action OnPlayerTakeDamage;
    public event Action<Enemy> OnEnemyDeadEvent;

    void Awake()
    {
        Instance = this;
    }

    public void PlayerDead()
    {
        OnPlayerDead?.Invoke();
    }  
    
    public void PlayerTakeDamage()
    {
        OnPlayerTakeDamage?.Invoke();
    }
    
    public void EnemyDead(Enemy enemy)
    {
        OnEnemyDeadEvent?.Invoke(enemy);
    }
}
