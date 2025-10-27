using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void TriggerHitAnimation()
    {
        animator.SetTrigger("Hit");
    }

    public void TriggerDeadAnimation()
    {
        animator.SetTrigger("Dead");
    }

    public void TriggerRandomDeadAnimation()
    {
        animator.SetInteger("RandomDeath", Random.Range(0, 2));
        TriggerDeadAnimation();
    }
}
