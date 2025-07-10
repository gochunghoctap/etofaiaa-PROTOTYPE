using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public float maxMana = 100f;
    private float currentMana;

    [HideInInspector] public HealthBar manaBar; // Dùng lại script HealthBar để hiển thị mana

    void Start()
    {
        currentMana = maxMana;
        UpdateManaBar();
    }

    void Update()
    {
        //RegenerateMana();
    }

    void RegenerateMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += 10f * Time.deltaTime; // tốc độ hồi mana
            currentMana = Mathf.Min(currentMana, maxMana);
            UpdateManaBar();
        }
    }
    public void RestoreMana(float amount)
    {
        currentMana += amount;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        UpdateManaBar();
    }


    public bool UseMana(float amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            UpdateManaBar();
            return true;
        }
        return false;
    }

    void UpdateManaBar()
    {
        if (manaBar != null)
        {
            float percent = Mathf.Clamp01(currentMana / maxMana);
            manaBar.SetHealthPercent(percent); // Dùng lại logic thanh máu
        }
    }
}