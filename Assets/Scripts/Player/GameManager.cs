using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;

    public Transform spawnPos1;
    public Transform spawnPos2;

    void Start()
    {
        StartMatch();
    }

    public void StartMatch()
    {
        // Tạo Player1
        var player1Obj = Instantiate(Player1Prefab, spawnPos1.position, Quaternion.identity);
        player1Obj.name = "Player1"; // Gán tên để dễ phân biệt nếu cần

        var playerInput1 = player1Obj.GetComponent<PlayerInput>();
        playerInput1.horizontalAxis = "Horizontal";
        playerInput1.attackKey = "Fire1";
        playerInput1.magicKey = "Fire2";
        playerInput1.guardKey = "Fire3";
        playerInput1.jumpKey = "Jump";

        // Gán HealthBar cho Player1
        var bar1Obj = GameObject.FindGameObjectWithTag("HealthBar_Player1");
        var healthBar1 = bar1Obj?.GetComponent<HealthBar>();
        player1Obj.GetComponent<HealthSystem>().healthBar = healthBar1;

        // Tạo Player2
        var player2Obj = Instantiate(Player2Prefab, spawnPos2.position, Quaternion.identity);
        player2Obj.name = "Player2";

        var playerInput2 = player2Obj.GetComponent<PlayerInput>();
        playerInput2.horizontalAxis = "Horizontal2";
        playerInput2.attackKey = "Fire1_2";
        playerInput2.magicKey = "Fire2_2";
        playerInput2.guardKey = "Fire3_2";
        playerInput2.jumpKey = "Jump2";

        // Gán HealthBar cho Player2
        var bar2Obj = GameObject.FindGameObjectWithTag("HealthBar_Player2");
        var healthBar2 = bar2Obj?.GetComponent<HealthBar>();
        player2Obj.GetComponent<HealthSystem>().healthBar = healthBar2;
    }
}