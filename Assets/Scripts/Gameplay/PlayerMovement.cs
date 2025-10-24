using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float verticalMovementSpeed;

    private Vector3 move = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Tick()
    {
        move = Vector3.zero;
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalMovementSpeed;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * verticalMovementSpeed;

        characterController.Move(move);
    }
}
