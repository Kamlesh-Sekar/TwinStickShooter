using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private HealthComponent healthComponent;
    private AnimatorController animatorController;
    private BoxCollider boxCollider;

    private Transform targetTransform;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<HealthComponent>();
        animatorController = GetComponent<AnimatorController>();
        boxCollider = GetComponent<BoxCollider>();
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
            animatorController.TriggerHitAnimation();
            agent.speed = 0f;
            StartCoroutine(MoveAgentAfterDelay(2.1f));
        }
    }

    private IEnumerator MoveAgentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        agent.speed = 0.5f;
    }

    public void OnDead()
    {
        EventManager.Instance.EnemyDead(this);
        agent.speed = 0f;
        agent.isStopped = true;
        boxCollider.enabled = false;
        animatorController.TriggerRandomDeadAnimation();
    }
}
