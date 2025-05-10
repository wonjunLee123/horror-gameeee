using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 涝仿 贸府
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D
        movement.y = Input.GetAxisRaw("Vertical");   // W, S
    }

    void FixedUpdate()
    {
        // 拱府 捞悼 贸府
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}