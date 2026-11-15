using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [SerializeField] private CameraController mainCamera;
    [SerializeField] private Transform cameraPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCamera.ChangeCameraPosition(cameraPosition);
        }
    }
}
