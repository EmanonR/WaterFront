using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public InputAction PlayerMovement;
    public InputAction MouseInput;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        PlayerMovement.Enable();
        MouseInput.Enable();
    }

    private void OnDisable()
    {
        PlayerMovement.Disable();
        MouseInput.Disable();
    }
}
