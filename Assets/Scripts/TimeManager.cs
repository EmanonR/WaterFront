using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] int SPS = 5;

    int currentTime = 0;
    float timer;
    bool counting = true;

    public static event Action<int> OnTimeChanged;

    public static TimeManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Update()
    {
        if (!counting)
            return;

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer -= 1f;
            currentTime += SPS;
            OnTimeChanged?.Invoke(currentTime);
        }
    }

    public int GetTime()
    {
        return currentTime;
    }

    public void StopTime()
    {
        counting = false;
    }

    public void ResumeTime()
    {
        counting = true;
    }
}
