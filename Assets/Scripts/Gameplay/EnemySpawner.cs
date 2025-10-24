using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    [SerializeField] private EnemyFactory enemyFactory;

    private List<Enemy> enemies = new List<Enemy>();
    private Player playerInstance;
    private Coroutine spawnCoroutine;

    public void Init(Player player)
    {
        playerInstance = player;
        StartSpawning();
    }

    private void Start()
    {
        EventManager.Instance.OnEnemyDeadEvent += OnEnemyDead;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeadEvent -= OnEnemyDead;
    }

    public void StartSpawning()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnInterval);
        Transform spawnTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Enemy enemyInstance = enemyFactory.Create(spawnTransform);
        enemies.Add(enemyInstance);
        enemyInstance.SetTarget(playerInstance.transform);
        spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void OnEnemyDead(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnCoroutine);
    }
}
