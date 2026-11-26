using System;
using UnityEngine;

public class FishFight : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] GameObject FightObject;
    [SerializeField] Transform Player;
    [SerializeField] Transform Fish;
    [SerializeField] Vector2 PlayerPos1, PlayerPos2;
    [SerializeField] Vector2 FishPos1, FishPos2;

    [Range(0,1)]
    [SerializeField] float playerWaterProg = 0, fishCaptureProg = 0;

    [Header("States")]
    [SerializeField] PlayerState playerState;
    [SerializeField] FishState fishState;

    public static event Action<bool> OnFightEnd;

    public Fish fish;

    bool inFight = false;
    bool fishPulling = false;
    float fishPullTime;
    float fishRecoveryTime;

    enum PlayerState
    {
        Recovering,
        Pulling,
        Resisting,
        Release
    }

    enum FishState
    {
        Idle,
        Pulling
    }

    private void Awake()
    {
        inFight = false;
        FightObject.SetActive(false);
    }

    public void StartFight(Fish incoming)
    {
        inFight = true;
        FightObject.SetActive(true);
        fish = incoming;
        playerWaterProg = 0;
        fishCaptureProg = 0;
        playerState = PlayerState.Recovering;
        fishState = FishState.Idle;
        fishPulling = false;
        fishPullTime = 0;

        fishRecoveryTime = UnityEngine.Random.Range(.5f, 2f);
    }

    private void Update()
    {
        if (!inFight) return;

        Player.transform.position = Vector2.Lerp(PlayerPos1, PlayerPos2, playerWaterProg);
        Fish.transform.position = Vector2.Lerp(FishPos1, FishPos2, fishCaptureProg);

        /*
         * Plan
         * player logic then enemy logic
         * 
         * player logic:
         * Start fight. o
         * pulling in fish. o
         * end fight. o
         * cutting line. o
         * recovering when no input. o
         * 
         * Fish logic:
         * randomness. o
         * pull player. x
         * player resist -> affects both. o
        */

        if (fishCaptureProg >= 1)
        {
            EndFight(true);
            return;
        }

        if (playerWaterProg >= 1)
        {
            //Also play cutscene and add onto time
            EndFight(false);
            return;
        }

        SetPlayerState();

        switch (playerState)
        {
            case PlayerState.Recovering:
                PlayerRecoverState();
                break;
            case PlayerState.Pulling:
                PlayerPullState();
                break;
            case PlayerState.Resisting:
                PlayerResistState();
                break;
            case PlayerState.Release:
                EndFight(false);
                break;
            default:
                PlayerRecoverState();
                break;
        }

        if (!fishPulling)
        {
            fishState = FishState.Idle;

            if (fishRecoveryTime > 0)
            {
                fishRecoveryTime -= Time.deltaTime;
                return;
            }

            if (UnityEngine.Random.Range(0, 100) < fish.agressiveness)
            {
                fishPullTime = UnityEngine.Random.Range(.5f, 2f);
                fishPulling = true;
            }
        }
        else
        {
            fishState = FishState.Pulling;

            fishPullTime -= Time.deltaTime;

            if (fishPullTime <= 0)
            {
                fishRecoveryTime = UnityEngine.Random.Range(.5f, 2f);

                fishPulling = false;
                return;
            }
        }
    }

    void PlayerRecoverState()
    {
        //Need to add stats here
        switch (fishState)
        {
            case FishState.Idle:
                playerWaterProg = Mathf.Clamp(playerWaterProg -= Time.deltaTime, 0, 1);
                break;
            case FishState.Pulling:
                playerWaterProg = Mathf.Clamp(playerWaterProg += Time.deltaTime * fish.pullStrength, 0, 1);
                fishCaptureProg = Mathf.Clamp(fishCaptureProg -= Time.deltaTime * fish.pullStrength, 0, 1);
                break;
            default:
                playerWaterProg = Mathf.Clamp(playerWaterProg -= Time.deltaTime, 0, 1);
                break;
        }
    }

    void PlayerPullState()
    {
        //Need to add stats here
        switch (fishState)
        {
            case FishState.Idle:
                fishCaptureProg = Mathf.Clamp(fishCaptureProg += Time.deltaTime, 0, 1);
                break;
            case FishState.Pulling:
                playerWaterProg = Mathf.Clamp(playerWaterProg += Time.deltaTime * fish.pullStrength, 0, 1);
                fishCaptureProg = Mathf.Clamp(fishCaptureProg -= Time.deltaTime * fish.pullStrength, 0, 1);
                break;
            default:
                fishCaptureProg = Mathf.Clamp(fishCaptureProg += Time.deltaTime, 0, 1);
                break;
        }
    }

    void PlayerResistState()
    {
        //Need to add stats here
        switch (fishState)
        {
            case FishState.Idle:
                break;
            case FishState.Pulling:
                playerWaterProg = Mathf.Clamp(playerWaterProg += (Time.deltaTime * fish.pullStrength / 2), 0, 1);
                fishCaptureProg = Mathf.Clamp(fishCaptureProg -= (Time.deltaTime * fish.pullStrength / 2), 0, 1);
                break;
            default:
                break;
        }
    }

    void SetPlayerState()
    {
        if (InputManager.Instance.fishReleaseKey.WasPressedThisFrame())
        {
            playerState = PlayerState.Release;
            return;
        }

        if (InputManager.Instance.fishPullKey.IsPressed())
            playerState = PlayerState.Pulling;
        else if (InputManager.Instance.fishResistKey.IsPressed())
            playerState = PlayerState.Resisting;
        else
            playerState = PlayerState.Recovering;
    }

    void EndFight(bool success)
    {
        inFight = false;
        FightObject.SetActive(false);
        OnFightEnd?.Invoke(success);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(PlayerPos1, PlayerPos2);
        Gizmos.DrawLine(FishPos1, FishPos2);
    }
}
