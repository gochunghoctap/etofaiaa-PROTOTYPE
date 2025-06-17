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
    private Animator animator;


    private int currentState = -1;
    public void SetActionState(int state)
    {
        if (currentState != state)
        {
            animator.SetInteger("ActionState", state);
            currentState = state;
        }
    }
//----------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();
    }
    //----------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Debug.Log($"isPerformingAction = {isPerformingAction}");
        if (isStunned)
        {
            SetActionState(6);
            return;
        }

        if (isPerformingAction)
        {
            rb.linearVelocity = Vector2.zero; // dừng hẳn khi đang hành động
            return;                    // KHÔNG nhận input di chuyển/jump gì cả
        }

        if (HandleActionInput())
            return;

        HandleMovement();
        HandleJump();
        UpdateAnimationState();
    }





    //----------------------------------------------------------------------------------------------------------------
    int facingDirection = 1;// save facing directions object
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
//----------------------------------------------------------------------------------------------------------------
    void HandleJump()
    {
        if (isGrounded && Input.GetButtonDown(playerInput.jumpKey))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // Không gọi SetActionState ở đây vì UpdateAnimationState sẽ xử lý jump
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    bool HandleActionInput()
    {
        if (isPerformingAction) return true;

        var action = playerInput.CurrentAction;
        switch (action)
        {
            case ActionType.Attack:
                SetActionState(3); // Attack
                rb.linearVelocity = Vector2.zero;
                isPerformingAction = true;
                playerInput.ConsumeAction();  // Reset action đã xử lý
                Debug.Log("▶ Bắt đầu hành động Attack");
                return true;
            case ActionType.Magic:
                SetActionState(4); // Magic
                rb.linearVelocity = Vector2.zero;
                isPerformingAction = true;
                playerInput.ConsumeAction();
                Debug.Log("▶ Bắt đầu hành động Magic");
                return true;
            case ActionType.Guard:
                SetActionState(5); // Guard
                rb.linearVelocity = Vector2.zero;
                isPerformingAction = true;
                playerInput.ConsumeAction();
                Debug.Log("▶ Bắt đầu hành động Guard");
                return true;
            default:
                return false;
        }
    }



    //----------------------------------------------------------------------------------------------------------------
    void UpdateAnimationState()
    {
        if (!isGrounded)
        {
            SetActionState(2); // Jump
        }
        else if (Mathf.Abs(playerInput.MoveInput) > 0.1f)
        {
            SetActionState(1); // Walk
        }
        else
        {
            SetActionState(0); // Idle
        }
    }
//----------------------------------------------------------------------------------------------------------------
    
    public void ApplyStun()
    {
        ApplyStunGuardBreak(0.5f); // stun mặc định 0.5s
    }

//----------------------------------------------------------------------------------------------------------------
    public void ApplyStunGuardBreak(float duration)
    {
        if (!isStunned)
            StartCoroutine(StunGuardBreakCoroutine(duration));
    }

    IEnumerator StunGuardBreakCoroutine(float duration)
    {
        isStunned = true;
        SetActionState(6); // Stunned animation
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }


//----------------------------------------------------------------------------------------------------------------
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
    //----------------------------------------------------------------------------------------------------------------

    private bool isPerformingAction = false;

    public void EndAction()
    {
        isPerformingAction = false;
        Debug.Log("Attack animation ended → return to Idle");
        SetActionState(0); // Quay lại Idle sau khi animation kết thúc
    }

}

