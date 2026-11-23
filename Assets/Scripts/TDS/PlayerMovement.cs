using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8;

    InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager == null) return;

        Vector2 moveInp = inputManager.PlayerMovement.ReadValue<Vector2>();

        if (moveInp.magnitude != 0) Movement(moveInp);
    }

    void Movement(Vector2 input)
    {
        transform.Translate(moveSpeed * Time.deltaTime * input);
    }
}
