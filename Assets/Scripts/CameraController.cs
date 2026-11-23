using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mousePower;

    private void LateUpdate()
    {
        transform.position = target.position + new Vector3(0, 0, -10);
    }
}
