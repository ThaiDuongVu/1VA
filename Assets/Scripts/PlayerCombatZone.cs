using UnityEngine;
using System.Collections.Generic;

public class PlayerCombatZone : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private Player player;

    // Update is called once per frame
    private void Update()
    {
        // If more than one enemy within combat zone then player enter combat
        if (enemies.Count > 0 && !player.IsInCombat)
        {
            player.Combat.EnterCombat();
            player.Movement.Stop();
        }

        // If no enemy within combat zone then player exit combat
        if (enemies.Count == 0 && player.IsInCombat)
            player.Combat.ExitCombat();
    }

    // Unlock all enemies within combat zone
    public void UnlockAll()
    {
        foreach (Enemy enemy in enemies)
            enemy.LockOn(false);
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Enemy to list
            Enemy enemy = other.GetComponent<Enemy>();
            enemies.Add(enemy);

            // Enemy enter combat
            enemy.Combat.EnterCombat();
            enemy.Movement.LookTarget = player.transform;
            enemy.Movement.MoveTarget = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Remove enemy from list
            Enemy enemy = other.GetComponent<Enemy>();
            enemies.Remove(enemy);

            // If enemy is locked then unlock it
            if (enemy.IsLockedOn) player.Unlock(enemy);

            // Enemy exit combat
            enemy.Combat.ExitCombat();
            enemy.Movement.LookTarget = null;
        }
    }

    #endregion
}
