using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mousePower;

    private void LateUpdate()
    {
        Vector2 mouseInp = InputManager.Instance.MouseInput.ReadValue<Vector2>();

        Vector2 mouseNormalized = (new Vector2((mouseInp.x / Screen.width) - .5f, (mouseInp.y / Screen.height) - .5f)) * 2;

        print(mouseNormalized);

        Vector2 offset = mouseNormalized * mousePower;

        transform.position = target.position + new Vector3(offset.x, offset.y, -10);
    }
}
