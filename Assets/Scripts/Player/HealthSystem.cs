using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isStunned = false;
    private float stunDuration = 0.5f;
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

    void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
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
        Destroy(this.gameObject);
    }

    public void ApplyStun()
    {
        if (!isStunned)
            StartCoroutine(StunCoroutine());
    }

    IEnumerator StunCoroutine()
    {
        isStunned = true;
        SetActionState(6);
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
        SetActionState(0);
    }
}
