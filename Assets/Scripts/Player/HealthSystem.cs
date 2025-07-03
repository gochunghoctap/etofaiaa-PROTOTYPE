using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [HideInInspector] public HealthBar healthBar; // Gán từ GameManager

    private PlayerController playerController;

    void Awake()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage)
    {
        if (playerController == null || playerController.IsStunned)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Không âm máu

        Debug.Log($"{gameObject.name} mất {damage} máu, còn {currentHealth}");

        if (healthBar != null)
        {
            float percent = Mathf.Clamp01((float)currentHealth / maxHealth);
            healthBar.SetHealthPercent(percent);

            // ✅ GỌI HÀM RUNG THANH MÁU
            healthBar.Shake(0.15f, 0.7f); // Thời gian và độ rung (tuỳ chỉnh nếu muốn)
        }

        if (currentHealth <= 0)
        {
            Die();
            SceneManager.LoadScene("End");
        }
        else
        {
            playerController.EndAction();
            playerController.ApplyStun(0.5f);
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} chết!");
        Destroy(gameObject);
    }
}
