using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private HealthComponent healthComponent;

    private Transform targetTransform;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        healthComponent.OnDeadEvent += OnDead;
    }

    private void OnDisable()
    {
        healthComponent.OnDeadEvent -= OnDead;
    }

    void Update()
    {
        if (targetTransform != null)
            agent.SetDestination(targetTransform.position);
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            healthComponent.TakeDamage(1);
        }
    }

    public void OnDead()
    {
        EventManager.Instance.EnemyDead(this);
        Destroy(gameObject);
    }
}
