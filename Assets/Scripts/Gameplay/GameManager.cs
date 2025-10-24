using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerFactory playerFactory;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private Transform startPosition;

    public void Play()
    {
        Player playerInstance = playerFactory.Create(startPosition);
        cameraMovement.SetTarget(playerInstance.transform);
        enemySpawner.Init(playerInstance);
        EventManager.Instance.OnPlayerDead += OnGameOver;
    }

    private void OnGameOver()
    {
        EventManager.Instance.OnPlayerDead -= OnGameOver;
        enemySpawner.StopSpawning();
    }
}
