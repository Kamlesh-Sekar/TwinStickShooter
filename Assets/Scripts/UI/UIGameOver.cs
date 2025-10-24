using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    public void Show()
    {
        gameObject.SetActive(true);
        restartButton.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void Hide()
    {
        restartButton.onClick.RemoveAllListeners();
        gameObject.SetActive(false);
    }
}
