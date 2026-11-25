using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public TMP_Text clockText;

    private void Awake()
    {
        //Subscribe to timeManager
        TimeManager.OnTimeChanged += UpdateText;
    }

    private void OnDestroy()
    {
        //Unsubscribe to timeManager
        TimeManager.OnTimeChanged -= UpdateText;
    }

    void UpdateText(int time)
    {
        if (clockText == null) return;

        //Function should feed in a quest object
        clockText.text = $"{Mathf.Floor(time / 60):00}:{time % 60:00}";
    }
}
