using UnityEngine;
using System.Collections.Generic;

public class PlayerViewCone : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<Enemy> _enemies = new List<Enemy>();


    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If view cone "see" an enemy then select it
        if (other.CompareTag("Enemy"))
        {
            Enemy otherEnemy = other.GetComponent<Enemy>();

            _enemies.Add(otherEnemy);
            _player.StartLock(otherEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If view cone not "see" any enemy then unlock all
        if (other.CompareTag("Enemy"))
        {
            Enemy otherEnemy = other.GetComponent<Enemy>();

            _player.Unlock(otherEnemy);
            _enemies.Remove(otherEnemy);

            if (_enemies.Count > 0) _player.StartLock(_enemies[_enemies.Count - 1]);
        }
    }

    #endregion
}
