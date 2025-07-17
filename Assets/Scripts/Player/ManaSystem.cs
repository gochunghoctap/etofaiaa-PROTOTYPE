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
    public bool RecoveryMana(float amount)
    {
        if (currentMana < maxMana)
        {
            currentMana += amount;
            UpdateManaBar();
            return true;
        }
        return false;
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

    public bool HasEnoughMana(float amount)
    {
        return currentMana >= amount;
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