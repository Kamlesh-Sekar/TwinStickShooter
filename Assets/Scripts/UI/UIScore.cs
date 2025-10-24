using System;
using System.Text;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private StringBuilder stringBuilder = new StringBuilder();
    [SerializeField] private string prefixText;
    private int currentScore = 0;

    private void OnEnable()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        UpdateScoreText();
        EventManager.Instance.OnEnemyDeadEvent += EnemyDead;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeadEvent -= EnemyDead;
    }

    private void EnemyDead(Enemy enemy)
    {
        AddScore();
    }

    private void AddScore()
    {
        currentScore++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        stringBuilder.Clear();
        stringBuilder.Append(prefixText);
        stringBuilder.Append(currentScore.ToString());
        scoreText.text = stringBuilder.ToString();
    }
}
