using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private UIStartScreen playScreen;
    [SerializeField] private UIGameOver gameOverScreen;
    [SerializeField] private UIGameHUD gameHUD;

    void Start()
    {
        playScreen.Show(OnPlayClicked);
        gameHUD.gameObject.SetActive(false);
    }

    private void OnPlayClicked()
    {
        gameManager.Play();
        EventManager.Instance.OnPlayerDead += ShowGameOverScreen;
        gameHUD.gameObject.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        EventManager.Instance.OnPlayerDead -= ShowGameOverScreen;
        gameHUD.gameObject.SetActive(false);
        gameOverScreen.Show();
    }
}
