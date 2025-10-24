using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private event Action OnPlayClickedEvent;

    public void Show(Action OnPlayClicked)
    {
        gameObject.SetActive(true);
        playButton.onClick.AddListener(Play);
        OnPlayClickedEvent = OnPlayClicked;
    }

    private void Play()
    {
        OnPlayClickedEvent?.Invoke();
        Hide();
    }

    public void Hide()
    {
        playButton.onClick.RemoveAllListeners();
        gameObject.SetActive(false);
    }
}
