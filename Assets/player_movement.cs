using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input (arrows or WASD)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // left/right
        moveInput.y = Input.GetAxisRaw("Vertical");   // up/down
    }

    void FixedUpdate()
    {
        // Apply physics-based movement
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}
