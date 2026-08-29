using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody playerBody;
    private Vector2 moveInput;
   
   [Header("Jump Settings")]
    public float jumpForce = 7f;
    private bool isJumping = false;
    private float initialYVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        initialYVelocity = playerBody.linearVelocity.y;
    }

    // FixedUpdate is called at a fixed interval and is better for physics updates
    void FixedUpdate()
    {
        Vector3 worldMove = transform.right * moveInput.x + transform.forward * moveInput.y;
        playerBody.linearVelocity = new Vector3(worldMove.x * moveSpeed,
                                                playerBody.linearVelocity.y,
                                                worldMove.z * moveSpeed);
        if (playerBody.linearVelocity.y != initialYVelocity)
        {
            initialYVelocity = playerBody.linearVelocity.y;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {

        // Only emable jumping if player is touching the ground
        if (context.performed && !isJumping)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Can we see if player velocity is changing?
        // Only allow jumping if velocity is not changing
    }

}
