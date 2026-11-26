using UnityEngine;

public class GameOverUI : SceneLoader
{
    [SerializeField] GameObject gameoverPanel;

    private void Awake()
    {
        TimeManager.OnDayEnd += OnGameOver; 
        gameoverPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        TimeManager.OnDayEnd -= OnGameOver;
    }

    void OnGameOver()
    {
        gameoverPanel.SetActive(true);
    }
}
