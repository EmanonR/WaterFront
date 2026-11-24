using UnityEngine;

public class FishingController : MonoBehaviour
{
    public FishingState fishingState;

    public enum FishingState
    {
        Starting,
        Waiting,
        Hooked,
        Reeling,
        Catch,
        Cancel
    }

    public void StartFishing()
    {

    }

    public void CancelFishing()
    {

    }

    public void EndFishing()
    {

    }
}
