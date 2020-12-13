using UnityEngine;

public class PlayerViewCone : MonoBehaviour
{
    [SerializeField] private Player _player;

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If view cone "see" an enemy then select it
        if (other.CompareTag("Enemy"))
            _player.StartLock(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If view cone not "see" any enemy then unlock all
        if (other.CompareTag("Enemy"))
            _player.Unlock();
    }

    #endregion
}
