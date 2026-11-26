using System;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    public FishingState fishingState;

    public enum FishingState
    {
        Idle,
        Waiting,
        Fighting
    }

    float timer;

    private void Update()
    {
        switch (fishingState)
        {
            case FishingState.Idle:
                if (InputManager.Instance.castKey.WasPressedThisFrame())
                {
                    print("You cast your line");
                    StartFishing();
                }
                break;
            case FishingState.Waiting:
                Waiting();
                break;
            case FishingState.Fighting:
                Fight();
                break;
            default:
                break;
        }
    }

    void Fight()
    {
        if (InputManager.Instance.fishPullKey.IsPressed())
            print("Pulling");
        else if (InputManager.Instance.fishResistKey.IsPressed())
            print("Resisting");
        else if (InputManager.Instance.fishReleaseKey.IsPressed())
        {
            print("Released fish");
            fishingState = FishingState.Idle;
        }
        else
            print("Recovering");
    }

    void Waiting()
    {
        if (InputManager.Instance.castKey.WasPressedThisFrame())
        {
            print("Cancel fishing");
            EndFishing();
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1f;
            fishingState = FishingState.Fighting;
            print("Fish on hook!");
        }
    }


    public void StartFishing()
    {
        print("Cast line!");
        timer = UnityEngine.Random.Range(1f, 2f);
        fishingState = FishingState.Waiting;
    }

    public void EndFishing()
    {
        print("Ending fish");
        fishingState = FishingState.Idle;
    }

    FishSize RollSize()
    {
        return (FishSize)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(FishSize)).Length);
    }

    void PickFish()
    {
        Item caughtFish = AreaInfo.CurrentAreaInfo.fishInArea[(int)UnityEngine.Random.Range(0, AreaInfo.CurrentAreaInfo.fishInArea.Count)];
        Inventory.Instance.AddItem(new InventoryItem(caughtFish, RollSize()));
    }
}
