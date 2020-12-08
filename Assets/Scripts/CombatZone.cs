using UnityEngine;

public class CombatZone : MonoBehaviour
{
    private Enemy[] _enemies;
    private EnemyCombat[] _enemyCombats;
    private EnemyMovement[] _enemyMovements;

    private Enemy _lockedOnEnemy;

    private void Awake()
    {
        // Get component references
        _enemies = new Enemy[transform.childCount];
        _enemyCombats = new EnemyCombat[_enemies.Length];
        _enemyMovements = new EnemyMovement[_enemies.Length];

        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies[i] = transform.GetChild(i).GetComponent<Enemy>();
            _enemyCombats[i] = _enemies[i].GetComponent<EnemyCombat>();
            _enemyMovements[i] = _enemies[i].GetComponent<EnemyMovement>();

            _enemies[i].combatZone = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Start combat
    public void StartCombat(Player player)
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            // All enemies enter combat state
            _enemyCombats[i].EnterCombat();
            // All enemies look at player
            _enemyMovements[i].lookTarget = player.transform;
        }
    }

    // End combat
    public void EndCombat()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            // All enemies exit combat state
            _enemyCombats[i].ExitCombat();
            // All enemies rest
            _enemyMovements[i].lookTarget = null;
        }
    }

    // Lock on an enemy
    public void LockOn(Enemy other)
    {
        UnlockAll();
        other.LockOn(true);
    }

    // Unlock all enemies
    public void UnlockAll()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.LockOn(false);
        }
    }
}
