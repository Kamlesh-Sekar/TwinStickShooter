using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthSystem : MonoBehaviour
{
    [SerializeField] private Image healthIcon;
    [SerializeField] private GameConfig gameConfig;

    private Stack<Image> icons = new Stack<Image>();

    private void OnEnable()
    {
        SpawnIcons(gameConfig.playerTotalHealth);
        EventManager.Instance.OnPlayerTakeDamage += ReduceHealth;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerTakeDamage -= ReduceHealth;
    }

    private void SpawnIcons(int totalHealth)
    {
        for (int i = 0; i < totalHealth; i++)
        {
            Image icon = Instantiate(healthIcon, gameObject.transform);
            icon.color = Color.red;
            icons.Push(icon);
        }
    }
    private void ReduceHealth()
    {
        Image icon = icons.Pop();
        icon.color = Color.white;
    }
}
