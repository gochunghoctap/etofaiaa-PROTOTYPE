using UnityEngine;

public enum ActionType { None, Attack, Magic, Guard }

public class PlayerInput : MonoBehaviour
{
    [Header("Input names")]
    public string horizontalAxis = "Horizontal";
    public string attackKey = "Fire1";
    public string magicKey = "Fire2";
    public string guardKey = "Fire3";
    public string jumpKey = "Jump";

    [HideInInspector] public float MoveInput;
    [HideInInspector] public ActionType CurrentAction { get; private set; } = ActionType.None;
    [HideInInspector] public bool JumpPressed = false;

    private bool actionQueued = false;

    void Update()
    {
        MoveInput = Input.GetAxisRaw(horizontalAxis);

        // Xử lý jump riêng biệt, không liên quan đến CurrentAction
        if (Input.GetButtonDown(jumpKey))
        {
            JumpPressed = true;
        }

        if (!actionQueued)
        {
            if (Input.GetButtonDown(attackKey))
            {
                CurrentAction = ActionType.Attack;
                actionQueued = true;
            }
            else if (Input.GetButtonDown(magicKey))
            {
                CurrentAction = ActionType.Magic;
                actionQueued = true;
            }
            else if (Input.GetButtonDown(guardKey))
            {
                CurrentAction = ActionType.Guard;
                actionQueued = true;
            }
        }
    }

    public void ConsumeAction()
    {
        CurrentAction = ActionType.None;
        actionQueued = false;
    }
}
