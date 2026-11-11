using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class RootMotionPlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    private Vector2 moveInput;

    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private float gravity = -9.81f;

    private float verticalVelocity;

    readonly int ANI_Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        ApplyGravity();

        Vector3 moveDirection =
            transform.forward * moveInput.y +
            transform.right * moveInput.x;

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat(
            ANI_Speed,
            moveInput.magnitude
        );
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded &&
            verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
    }

    private void OnAnimatorMove()
    {
        Vector3 rootMotion = animator.deltaPosition;

        rootMotion.y = verticalVelocity * Time.deltaTime;

        characterController.Move(rootMotion);
    }
}