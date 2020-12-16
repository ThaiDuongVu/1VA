using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private Enemy _enemy;

    private static readonly int ExitCombatTrigger = Animator.StringToHash("exitCombat");
    private static readonly int EnterCombatTrigger = Animator.StringToHash("enterCombat");

    private void Awake()
    {
        // Get component references
        _enemy = GetComponent<Enemy>();
    }

    // Enemy enter combat state
    public void EnterCombat()
    {
        // Play combat animation
        _enemy.Animator.ResetTrigger(ExitCombatTrigger);
        _enemy.Animator.SetTrigger(EnterCombatTrigger);

        // Set state
        _enemy.IsInCombat = true;
        _enemy.State = EnemyState.CombatWander;
    }

    // Enemy exit combat state
    public void ExitCombat()
    {
        // Stop combat animation
        _enemy.Animator.ResetTrigger(EnterCombatTrigger);
        _enemy.Animator.SetTrigger(ExitCombatTrigger);

        // Set state
        _enemy.IsInCombat = false;
        _enemy.Movement.StartPursuit();
    }
}