using UnityEngine;

public enum ActionType { None, Attack, Magic, Guard, Jump }

public class PlayerInput : MonoBehaviour
{
    [Header("Input names")]
    public string horizontalAxis = "Horizontal";
    public string attackKey = "Fire1";
    public string magicKey = "Fire2";
    public string guardKey = "Fire3";
    public string jumpKey = "Jump";

    [HideInInspector] public float MoveInput;
    [HideInInspector] public ActionType CurrentAction = ActionType.None;
    [HideInInspector] public bool JumpPressed = false;

    void Update()
    {
        MoveInput = Input.GetAxisRaw(horizontalAxis);

        if (Input.GetButtonDown(attackKey))
            CurrentAction = ActionType.Attack;
        else if (Input.GetButtonDown(magicKey))
            CurrentAction = ActionType.Magic;
        else if (Input.GetButtonDown(guardKey))
            CurrentAction = ActionType.Guard;
        else
            CurrentAction = ActionType.None;

        JumpPressed = Input.GetButtonDown(jumpKey);
        if(Input.GetButtonDown(jumpKey))
            CurrentAction = ActionType.Jump;
    }
}
