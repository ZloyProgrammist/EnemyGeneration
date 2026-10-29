using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Настройки спавнера")]
    [SerializeField, Tooltip("Префаб врага")] private Enemy _prefab;
    [SerializeField, Tooltip("Точки спавна врага")] private Transform[] _spawnPoints;
    [SerializeField, Tooltip("Интервал между спавнами врага")] private float _spawnInterval = 2f;
    [SerializeField] private Transform _target;

    private float _timer = 0;

    private void Awake()
    {
        if (_prefab == null)
            Debug.LogError($"{nameof(EnemySpawner)}: не назначен префаб существа!");

        if (_spawnPoints == null || _spawnPoints.Length == 0)
            Debug.LogError($"{nameof(EnemySpawner)}: не назначено ни одной точки спавна!");
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        Enemy enemy = Instantiate(_prefab, spawnPosition);
        enemy.Instantiate(_target);
    }
}
