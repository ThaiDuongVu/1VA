using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        Fly();
    }

    /// <summary>
    // Fly bullet forward.
    /// </summary>
    private void Fly()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }
}
