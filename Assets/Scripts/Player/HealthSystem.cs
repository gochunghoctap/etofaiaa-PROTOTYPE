using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isStunned = false;
    private float stunDuration = 0.5f;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isStunned)
            return; // có thể điều chỉnh tùy ý

        currentHealth -= damage;
        Debug.Log($"{gameObject.name} mất {damage} máu, còn {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            ApplyStun();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} chết!");
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
}
