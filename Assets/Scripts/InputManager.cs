using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction castKey;
    public InputAction inventoryKey;
    public InputAction mapKey;
    public InputAction interactKey;
    public InputAction cancelKey;

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;

        castKey.Enable();
        inventoryKey.Enable();
        mapKey.Enable();
        interactKey.Enable();
        cancelKey.Enable();
    }

    private void OnDestroy()
    {
        castKey.Disable();
        inventoryKey.Disable();
        mapKey.Disable();
        interactKey.Disable();
        cancelKey.Disable();
    }
}
