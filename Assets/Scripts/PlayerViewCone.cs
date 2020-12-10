using UnityEngine;

public class PlayerViewCone : MonoBehaviour
{
    public Player player;

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            player.StartLock(other.GetComponent<Enemy>());
        }
    }

    #endregion
}
