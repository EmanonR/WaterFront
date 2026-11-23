using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mousePower;

    private void LateUpdate()
    {
        Vector2 mouseNormalized = InputManager.Instance.GetMouseInputDirection();

        Vector2 offset = mouseNormalized * mousePower;

        transform.position = target.position + new Vector3(offset.x, offset.y, -10);
    }
}
