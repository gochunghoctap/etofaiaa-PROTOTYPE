using UnityEngine;

public class BattleController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;

    // 基本ダメジ
    public int damageAmount = 10;

    void Update()
    {
        ProcessActions();
    }

    void ProcessActions()
    {
        var action1 = player1.playerInput.CurrentAction;
        var action2 = player2.playerInput.CurrentAction;

        if (action1 == ActionType.None && action2 == ActionType.None)
            return;

        // Xử lý từng trường hợp có ít nhất 1 hành động

        // Nếu cả 2 cùng hành động thì xét xem có counter nhau không
        if (action1 != ActionType.None && action2 != ActionType.None)
        {
            ResolveCombat(action1, player1, action2, player2);
            ResolveCombat(action2, player2, action1, player1);
        }
        else if (action1 != ActionType.None)
        {
            // Player 1 đánh, Player 2 không làm gì
            player2.GetComponent<HealthSystem>().TakeDamage(damageAmount);
            player2.ApplyStun();
        }
        else if (action2 != ActionType.None)
        {
            // Player 2 đánh, Player 1 không làm gì
            player1.GetComponent<HealthSystem>().TakeDamage(damageAmount);
            player1.ApplyStun();
        }
    }

    void ResolveCombat(ActionType attackerAction, PlayerController attacker, ActionType defenderAction, PlayerController defender)
    {
        // Logic khắc chế: Attack > Magic > Guard > Attack

        bool attackerWins = false;
        bool noDamage = false;

        if (attackerAction == ActionType.Attack && defenderAction == ActionType.Magic)
            attackerWins = true;
        else if (attackerAction == ActionType.Magic && defenderAction == ActionType.Guard)
            attackerWins = true;
        else if (attackerAction == ActionType.Guard && defenderAction == ActionType.Attack)
        {
            // Guard counter Attack - không sát thương, không stun defender
            noDamage = true;
            attackerWins = false;
        }

        if (attackerWins)
        {
            // Attacker thắng, defender bị damage + stun
            defender.GetComponent<HealthSystem>().TakeDamage(damageAmount);
            defender.ApplyStun();
        }
        else if (!noDamage)
        {
            // Nếu không thắng và không phải trường hợp guard counter attack thì defender counter lại attacker
            // Áp dụng stun attacker, có thể giảm máu tùy thiết kế
            attacker.ApplyStun();
            // Nếu muốn attacker cũng bị mất máu khi bị counter thì gọi TakeDamage ở đây
            attacker.GetComponent<HealthSystem>().TakeDamage(damageAmount);
        }
        // Nếu noDamage = true thì không làm gì thêm (defender không bị stun và không mất máu)
    }
}
