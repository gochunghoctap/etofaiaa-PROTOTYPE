using UnityEngine;

public class hitsujiTEST_Magic : MonoBehaviour
{
    public int damage = 20;
    private bool canDealDamage = true;

    private void OnEnable()
    {
        canDealDamage = true; // reset mỗi lần bật hitbox
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!canDealDamage) return;
        if (other.gameObject == transform.root.gameObject) return; //khong gay damage len ban than

        var health = other.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(damage);
            canDealDamage = false; // chỉ gây damage 1 lần mỗi lần bật
        }
    }
}
