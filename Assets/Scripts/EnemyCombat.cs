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

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Enemy enter combat state
    public void EnterCombat()
    {
        // Play combat animation
        _enemy.Animator.ResetTrigger(ExitCombatTrigger);
        _enemy.Animator.SetTrigger(EnterCombatTrigger);

        // Set state
        _enemy.IsInCombat = true;
        _enemy.State = EnemyState.CombatWalk;
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