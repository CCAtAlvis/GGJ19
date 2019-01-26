using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    public Vector3 cameraPositionOffset;
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + cameraPositionOffset;
        }
    }
}