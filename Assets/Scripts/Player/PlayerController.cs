using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isStunned = false;
    private float stunDuration = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (isStunned)
            return;

        HandleMovement();
        HandleJump();
        HandleActionInput();
    }

    void HandleMovement()
    {
        float move = playerInput.MoveInput;
        Vector2 velocity = rb.linearVelocity;
        velocity.x = move * moveSpeed;
        rb.linearVelocity = new Vector2(velocity.x, rb.linearVelocity.y);
    }

    void HandleJump()
    {
        if (isGrounded && Input.GetButtonDown(playerInput.jumpKey))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void HandleActionInput()
    {
        var action = playerInput.CurrentAction;
        if (action != ActionType.None)
        {
            Debug.Log($"{gameObject.name} thực hiện {action}");
            // TODO: xử lý attack, magic, guard...
        }
    }

    public void ApplyStun()
    {
        if (!isStunned)
            StartCoroutine(StunCoroutine());
    }

    IEnumerator StunCoroutine()
    {
        isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }

    // --- Collider trigger để xác định grounded ---
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            // Debug.Log("Đã chạm đất");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            // Debug.Log("Rời khỏi đất");
        }
    }
}
