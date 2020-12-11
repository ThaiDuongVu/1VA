using UnityEngine;

public class PlayerViewCone : MonoBehaviour
{
    [SerializeField] private Player player;

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If view cone "see" an enemy then select it
        if (other.CompareTag("Enemy"))
            player.StartLock(other.GetComponent<Enemy>());
    }

    #endregion
}
