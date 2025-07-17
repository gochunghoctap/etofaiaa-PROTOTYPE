using UnityEngine;

public enum ActionType { None, Attack, Magic, Guard, Abiru }

public class PlayerInput : MonoBehaviour
{
    [Header("Input names")]
    public string horizontalAxis = "Horizontal";
    public string attackKey = "Fire1";
    public string magicKey = "Fire2";
    public string guardKey = "Fire3";
    public string abiruKey = "Fire4";
    public string jumpKey = "Jump";
    
    public ManaSystem manaSystem;
    public float manaCost1 = 30f;
    public float manaCost2 = 10f;
    public float manaCost3 = 15f;
    

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
            else if (Input.GetButtonDown(magicKey) && manaSystem.HasEnoughMana(manaCost1))
            {
                CurrentAction = ActionType.Magic;
                actionQueued = true;
                manaSystem.UseMana(manaCost1);
            }
            else if (Input.GetButtonDown(guardKey) && manaSystem.HasEnoughMana(manaCost2))
            {
                CurrentAction = ActionType.Guard;
                actionQueued = true;
                manaSystem.UseMana(manaCost2);
            }
            else if (Input.GetButtonDown(abiruKey))
            {
                CurrentAction = ActionType.Abiru;
                actionQueued = true;
                manaSystem.RecoveryMana(manaCost3);
            }
        }
    }

    public void ConsumeAction()
    {
        CurrentAction = ActionType.None;
        actionQueued = false;
    }
}
