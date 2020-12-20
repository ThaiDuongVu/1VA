using UnityEngine;

public class PlayerViewCone : MonoBehaviour
{
    [SerializeField] private Player player;

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If view cone "see" an enemy then select it
        if (other.CompareTag("Enemy"))
        {
            Enemy otherEnemy = other.GetComponent<Enemy>();

            player.EnemiesInViewCone.Add(otherEnemy);
            player.StartLock(otherEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If view cone not "see" any enemy then unlock all
        if (other.CompareTag("Enemy"))
        {
            Enemy otherEnemy = other.GetComponent<Enemy>();

            player.Unlock(otherEnemy);
            player.EnemiesInViewCone.Remove(otherEnemy);

            if (player.EnemiesInViewCone.Count > 0) player.StartLock(player.EnemiesInViewCone[player.EnemiesInViewCone.Count - 1]);
        }
    }

    #endregion
}