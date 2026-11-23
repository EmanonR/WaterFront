using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public InputAction PlayerMovement;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        PlayerMovement.Disable();
    }
}
