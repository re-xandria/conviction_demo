using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody playerBody;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at a fixed interval and is better for physics updates
    void FixedUpdate()
    {
        Vector3 worldMove = transform.right * moveInput.x + transform.forward * moveInput.y;
        playerBody.linearVelocity = new Vector3(worldMove.x * moveSpeed,
                                                playerBody.linearVelocity.y,
                                                worldMove.z * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && playerBody.position.y <= 0.1f)
        {
            playerBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

}
