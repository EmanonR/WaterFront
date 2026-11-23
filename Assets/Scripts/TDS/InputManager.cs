using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public InputAction PlayerMovement;
    public InputAction MouseInput;
    public InputAction ShootInput;

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
        ShootInput.Enable();
    }

    private void OnDisable()
    {
        PlayerMovement.Disable();
        MouseInput.Disable();
        ShootInput.Disable();
    }

    public Vector2 GetMouseInputDirection()
    {
        Vector2 mouseInp = InputManager.Instance.MouseInput.ReadValue<Vector2>();

        return new Vector2((mouseInp.x / Screen.width) - .5f, (mouseInp.y / Screen.height) - .5f) * 2;
    }
}
