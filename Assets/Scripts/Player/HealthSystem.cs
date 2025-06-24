using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;


    private PlayerController playerController; // ✅ Tham chiếu đến PlayerController

    public void Awake()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
    }


    public void TakeDamage(int damage)
    {
        if (playerController == null || playerController.IsStunned)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ngăn âm máu

        Debug.Log($"{gameObject.name} mất {damage} máu, còn {currentHealth}");

        if (healthBar != null)
        {
            float percent = (float)currentHealth / maxHealth;
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

    void Die()
    {
        Debug.Log($"{gameObject.name} chết!");
        Destroy(this.gameObject);
    }
}
