using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void ChangeCameraPosition(Transform newPosition)
    {
        if (newPosition == null) return;

        transform.position = newPosition.position;
    }
}
