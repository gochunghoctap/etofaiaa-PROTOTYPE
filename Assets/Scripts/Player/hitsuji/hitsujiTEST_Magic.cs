using UnityEngine;

public class hitsujiTEST_Magic : MonoBehaviour
{
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Không tự đánh chính mình
        if (other.gameObject == transform.root.gameObject) return;

        if (other.CompareTag("Player"))
        {
            var health = other.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            // Tắt hitbox sau khi đánh trúng để không gây nhiều damage liên tục
            gameObject.SetActive(false);
        }
    }
}
