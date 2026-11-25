using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction castKey;
    public InputAction catchKey;
    public InputAction inventoryKey;
    public InputAction mapKey;

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
        catchKey.Enable();
        inventoryKey.Enable();
        mapKey.Enable();
    }

    private void OnDestroy()
    {
        castKey.Disable();
        catchKey.Disable();
        inventoryKey.Disable();
        mapKey.Disable();
    }
}
