using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackDecay;

    private Vector3 knockbackVelocity;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Tick()
    {
        knockbackVelocity = Vector3.Lerp(knockbackVelocity, Vector3.zero, Time.deltaTime * knockbackDecay);
        characterController.Move(knockbackVelocity * Time.deltaTime);
    }
    public void ApplyKnockback(Vector3 sourcePosition)
    {
        Vector3 direction = (transform.position - sourcePosition).normalized;
        direction.y = 0;
        knockbackVelocity = direction * knockbackForce;
    }
}
