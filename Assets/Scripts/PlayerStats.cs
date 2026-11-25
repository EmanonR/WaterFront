using System;
using UnityEngine;

public static class PlayerStats
{
    public static int level;
    public static int xp;

    public static event Action<int> OnXpChanged;
    public static event Action<int> OnLevelChanged;

    public static void AddXP(int incoming)
    {
        xp += incoming;

        int levelsGot = 0;

        for (int i = 0; i < Mathf.Floor(xp / 100); i++)
        {
            levelsGot++;
            xp -= 100;
        }

        OnXpChanged?.Invoke(xp);

        if (levelsGot > 0)
        {
            level += levelsGot;
            OnLevelChanged?.Invoke(levelsGot);
        }
    }
}
