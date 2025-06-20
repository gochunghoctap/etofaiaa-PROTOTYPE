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
    private bool isPerformingAction = false;

    private Animator animator;
    private int facingDirection = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (isStunned)
        {
            animator.SetBool("isStunned", true);
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        if (isPerformingAction)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        if (HandleActionInput())
            return;

        HandleMovement();
        HandleJump();
        UpdateAnimationState();
    }

    void HandleMovement()
    {
        float move = playerInput.MoveInput;
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (Mathf.Abs(move) > 0.01f)
        {
            facingDirection = move > 0 ? -1 : 1;
            transform.localScale = new Vector3(facingDirection, 1, 1);
        }
    }

    void HandleJump()
    {
        if (isGrounded && playerInput.JumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerInput.JumpPressed = false; // Chỉ reset JumpPressed, không ảnh hưởng action khác
        }
    }

    bool HandleActionInput()
    {
        if (isPerformingAction) return true;

        var action = playerInput.CurrentAction;
        if (action == ActionType.None) return false;

        switch (action)
        {
            case ActionType.Attack:
                animator.SetTrigger("Trigger_Attack");
                break;
            case ActionType.Magic:
                animator.SetTrigger("Trigger_Magic");
                break;
            case ActionType.Guard:
                animator.SetTrigger("Trigger_Guard");
                break;
        }

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        isPerformingAction = true;
        playerInput.ConsumeAction();
        return true;
    }

    void UpdateAnimationState()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isRunning", Mathf.Abs(playerInput.MoveInput) > 0.1f);
        animator.SetBool("isJumping", !isGrounded && rb.linearVelocity.y > 0.1f);
        animator.SetBool("isFalling", !isGrounded && rb.linearVelocity.y < -0.1f);
    }

    public void ApplyStun(float duration = 0.5f)
    {
        if (!isStunned)
            StartCoroutine(StunCoroutine(duration));
    }

    IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        animator.SetBool("isStunned", true);
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        yield return new WaitForSeconds(duration);

        isStunned = false;
        animator.SetBool("isStunned", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = false;
    }

    public void EndAction()
    {
        isPerformingAction = false;
    }
}
