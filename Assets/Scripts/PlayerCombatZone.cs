using UnityEngine;

public class PlayerCombatZone : MonoBehaviour
{
    [SerializeField] private Player player;

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Enemy to list
            Enemy enemy = other.GetComponent<Enemy>();
            player.EnemiesInCombatZone.Add(enemy);

            // Enemy enter combat
            enemy.Combat.EnterCombat();

            Transform playerTransform = player.transform;
            enemy.Movement.LookTarget = playerTransform;
            enemy.Movement.MoveTarget = playerTransform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Remove enemy from list
            Enemy enemy = other.GetComponent<Enemy>();
            player.EnemiesInCombatZone.Remove(enemy);

            // If enemy is locked then unlock it
            if (enemy.IsLockedOn) player.Unlock(enemy);

            // Enemy exit combat
            enemy.Combat.ExitCombat();
            enemy.Movement.LookTarget = null;
        }
    }

    #endregion
}