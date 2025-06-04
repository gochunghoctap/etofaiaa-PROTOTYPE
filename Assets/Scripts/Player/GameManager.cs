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
        var player1Obj = Instantiate(Player1Prefab, spawnPos1.position, Quaternion.identity);
        var playerInput1 = player1Obj.GetComponent<PlayerInput>();
        playerInput1.horizontalAxis = "Horizontal";
        playerInput1.attackKey = "Fire1";
        playerInput1.magicKey = "Fire2";
        playerInput1.guardKey = "Fire3";
        playerInput1.jumpKey = "Jump";

        var player2Obj = Instantiate(Player2Prefab, spawnPos2.position, Quaternion.identity);
        var playerInput2 = player2Obj.GetComponent<PlayerInput>();
        playerInput2.horizontalAxis = "Horizontal2";
        playerInput2.attackKey = "Fire1_2";
        playerInput2.magicKey = "Fire2_2";
        playerInput2.guardKey = "Fire3_2";
        playerInput2.jumpKey = "Jump2";
    }
}
