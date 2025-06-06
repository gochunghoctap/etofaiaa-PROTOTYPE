using UnityEngine;
using UnityEngine.UI;

public class P2B : MonoBehaviour
{
    public Button showButton;       // 表示するボタン
    public GameObject prefabToSpawn;      // 表示される画像（Imageコンポーネント）
    public Transform spawnPoint;

    public void Start()
    {

        // ボタンにクリックイベントを登録
        showButton.onClick.AddListener(ShowPhoto);
    }

    void ShowPhoto()
    {
        GameObject newObj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

        spawnPoint.gameObject.SetActive(false);//後でselectmanagerをcheck

        // スクリプトを無効にする
        PlayerController script = newObj.GetComponent<PlayerController>();
        if (script != null)
        {
            script.enabled = false;
        }

        Rigidbody2D rb2d = newObj.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.gravityScale = 0f; // 重力スケールを0にする
            rb2d.linearVelocity = Vector2.zero; // 念のため速度も0にする
        }
    }
}
