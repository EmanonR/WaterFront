using System;

public static class PlayerStats
{
    public static int level;
    public static int xp;

    public static event Action<int> OnXpChanged;
    public static event Action<int> OnLevelChanged;



    public static void Reset()
    {
        level = 0;
        xp = 0;
    }

    public static void AddXP(int incoming)
    {
        xp += incoming;

        int levelsGot = 0;

        while (xp >= 100)
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
