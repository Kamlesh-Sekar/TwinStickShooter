using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerRotation rotation;
    private PlayerShooting shooting;
    private Knockback knockback;
    private HealthComponent health;

    [SerializeField] private GameConfig gameConfig;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
        shooting = GetComponent<PlayerShooting>();
        health = GetComponent<HealthComponent>();
        knockback = GetComponent<Knockback>();
        health.SetStartHealth(gameConfig.playerTotalHealth);
    }

    private void OnEnable()
    {
        health.OnDeadEvent += OnDead;
    }

    private void OnDisable()
    {
        health.OnDeadEvent -= OnDead;
    }

    void Update()
    {
        movement.Tick();
        rotation.Tick();
        shooting.Tick();
        knockback.Tick();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            health.TakeDamage(1);
            knockback.ApplyKnockback(other.transform.position);
            EventManager.Instance.PlayerTakeDamage();
        }
    }

    private void OnDead()
    {
        EventManager.Instance.PlayerDead();
        gameObject.SetActive(false);
    }
}
