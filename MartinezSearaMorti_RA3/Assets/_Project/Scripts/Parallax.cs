using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.1f;
    private Material parallaxMaterial;

    [SerializeField] private Transform camera;
    private float lastCameraX;
    void Start()
    {
        parallaxMaterial = GetComponent<Renderer>().material;
        lastCameraX = camera.position.x;
    }

    void LateUpdate()
    {
        float deltax = camera.position.x - lastCameraX;
        parallaxMaterial.mainTextureOffset += new Vector2(deltax * parallaxMultiplier, 0);
        lastCameraX = camera.position.x;
    }
}
