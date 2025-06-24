using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private HealthBar healthBar;

    private PlayerController playerController; // ✅ Tham chiếu đến PlayerController

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        playerController = GetComponent<PlayerController>(); // ✅ Gán tự động
    }

    public void TakeDamage(int damage)
    {
        if (playerController == null) return;

        if (playerController.IsStunned)
            return; // Nếu đang choáng, bỏ qua sát thương (tuỳ vào gameplay bạn muốn)

        currentHealth -= damage;
        Debug.Log($"{gameObject.name} mất {damage} máu, còn {currentHealth}");

        // ✅ Cập nhật HP bar ở đây
        float healthFraction = (float)currentHealth / maxHealth;
        if (healthBar != null)
            healthBar.SetHealthPercent((float)currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            playerController.EndAction();            // ✅ Ngắt action hiện tại nếu có
            playerController.ApplyStun(0.5f);         // ✅ Gọi stun đồng bộ với controller
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} chết!");
        Destroy(this.gameObject);
    }
}
