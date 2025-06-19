using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;               // Máu tối đa
    private int currentHealth;                // Máu hiện tại
    private bool isStunned = false;           // Trạng thái choáng
    private float stunDuration = 0.5f;        // Thời gian bị choáng
    private Animator animator;                // Animator của nhân vật

    void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Gọi khi nhận sát thương
    public void TakeDamage(int damage)
    {
        if (isStunned)
            return; // Nếu đang choáng thì bỏ qua sát thương tiếp theo (tuỳ chỉnh được)

        currentHealth -= damage;
        Debug.Log($"{gameObject.name} mất {damage} máu, còn {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            ApplyStun(); // Bị choáng khi còn sống
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} chết!");
        Destroy(this.gameObject); // Xoá object khỏi scene
    }

    // Gọi stun và khởi chạy coroutine
    public void ApplyStun()
    {
        if (!isStunned)
            StartCoroutine(StunCoroutine());
    }

    // Coroutine xử lý trạng thái choáng
    IEnumerator StunCoroutine()
    {
        isStunned = true;
        animator.SetBool("isStunned", true); // Bật trạng thái choáng
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
        animator.SetBool("isStunned", false); // Tắt trạng thái choáng
    }
}