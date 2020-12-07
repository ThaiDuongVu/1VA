using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private Enemy _enemy;

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
        _enemy.animator.ResetTrigger("exitCombat");
        _enemy.animator.SetTrigger("enterCombat");

        // Set state
        _enemy.isInCombat = true;
    }

    // Enemy exit combat state
    public void ExitCombat()
    {
        // Stop combat animation
        _enemy.animator.ResetTrigger("enterCombat");
        _enemy.animator.SetTrigger("exitCombat");

        // Set state
        _enemy.isInCombat = false;
    }
}
