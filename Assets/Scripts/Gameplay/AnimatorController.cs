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
}
