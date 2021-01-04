using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;

public class WeaponAimCone : MonoBehaviour
{
    private Light2D light2D;

    [SerializeField] private Color32 normalColor;
    [SerializeField] private Color32 aimColor;

    private List<Enemy> enemies = new List<Enemy>();
    public int EnemyCount => enemies.Count;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        this.enabled = false;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        if (enemies.Count > 0)
        {
            light2D.color = aimColor;
        }
        else
        {
            light2D.color = normalColor;
        }
    }

    /// <summary>
    /// Unity Event function.
    /// Handle when enemy enter aim cone.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemies.Add(enemy);
            enemy.OnTargeted(true);
        }
    }

    /// <summary>
    /// Unity Event function.
    /// Handle when enemy exit aim cone.
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemies.Remove(enemy);
            enemy.OnTargeted(false);
        }
    }
}
