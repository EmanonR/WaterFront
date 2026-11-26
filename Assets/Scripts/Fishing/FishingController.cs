using System;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    public FishingState fishingState;
    public FishFight fight;

    public enum FishingState
    {
        Idle,
        Waiting,
        StartFight,
        InFight
    }

    float timer;

    private void Awake()
    {
        fight = GetComponent<FishFight>(); 
        FishFight.OnFightEnd += EndFishing;
    }

    private void OnDestroy()
    {
        FishFight.OnFightEnd -= EndFishing;
    }

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
            case FishingState.StartFight:
                fight.StartFight(AreaInfo.CurrentAreaInfo.fishInArea[UnityEngine.Random.Range(0, AreaInfo.CurrentAreaInfo.fishInArea.Count)]);
                fishingState = FishingState.InFight;
                break;
            case FishingState.InFight:
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
            EndFishing(false);
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1f;
            fishingState = FishingState.StartFight;
            print("Fish on hook!");
        }
    }


    public void StartFishing()
    {
        print("Cast line!");
        timer = UnityEngine.Random.Range(1f, 2f);
        fishingState = FishingState.Waiting;
    }

    public void EndFishing(bool success)
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
