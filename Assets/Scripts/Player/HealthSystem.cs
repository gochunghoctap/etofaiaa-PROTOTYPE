using UnityEngine;

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
        }

        if (currentHealth <= 0)
        {
            Die();
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