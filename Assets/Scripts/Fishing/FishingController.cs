using System;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    public FishingState fishingState;

    public enum FishingState
    {
        Idle,
        Waiting,
        Hooked,
        Catch
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
            case FishingState.Hooked:
                Hooked();
                break;
            case FishingState.Catch:
                print("Caught a fish");
                PickFish();
                EndFishing();
                break;
            default:
                break;
        }
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
            fishingState = FishingState.Hooked;
            print("Fish on hook!");
        }
    }

    void Hooked()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            print("It got away...");
            EndFishing();
            return;
        }

        if (InputManager.Instance.castKey.WasPressedThisFrame())
            fishingState = FishingState.Catch;
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
