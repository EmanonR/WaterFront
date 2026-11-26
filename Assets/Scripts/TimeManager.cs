using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] int minutesPerDay = 10;

    int startTime = 480;
    int targetTime = 1200;
    float currentTime = 480;
    float timer;
    bool counting = true;

    public static event Action<int> OnTimeChanged;
    public static event Action OnDayEnd;

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


        currentTime = startTime;
        OnTimeChanged?.Invoke((int)currentTime);
    }

    private void Update()
    {
        if (!counting)
            return;

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer -= 1f;
            AddTime((float)((float)targetTime - (float)startTime) / (float)((float)minutesPerDay * 60f));
        }
    }

    public float GetTime()
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

    public void AddTime(float addition)
    {
        currentTime += addition;
        OnTimeChanged?.Invoke((int)currentTime);

        if (currentTime >= targetTime)
            OnDayEnd?.Invoke();
    }
}
