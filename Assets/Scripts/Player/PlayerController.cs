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
        if (isStunned)
        {
            SetActionState(6); // Stunned
            return;
        }

        HandleMovement();
        HandleJump();
        if (!HandleActionInput())  // nếu không có action đặc biệt thì update animation trạng thái bình thường
        {
            UpdateAnimationState();
        }
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
        var action = playerInput.CurrentAction;
        switch (action)
        {
            case ActionType.Attack:
                SetActionState(3);
                return true;
            case ActionType.Magic:
                SetActionState(4);
                return true;
            case ActionType.Guard:
                SetActionState(5);
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
}




/*if (action != ActionType.None)
        {
            Debug.Log($"{gameObject.name} thực hiện {action}");
            // TODO: xử lý attack, magic, guard...
        }*/