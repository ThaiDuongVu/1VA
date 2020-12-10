using UnityEngine;
using System.Collections.Generic;

public class PlayerCombatZone : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();

    public Player player;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (enemies.Count > 0 && !player.IsInCombat)
        {
            player.Combat.EnterCombat();
            player.Movement.Stop();
        }

        if (enemies.Count == 0 && player.IsInCombat)
            player.Combat.ExitCombat();
    }

    public void UnlockAll()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.LockOn(false);
        }
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemies.Add(enemy);
            enemy.Combat.EnterCombat();
            enemy.Movement.LookTarget = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemies.Remove(enemy);
            enemy.Combat.ExitCombat();
            enemy.Movement.LookTarget = null;
        }
    }

    #endregion
}
