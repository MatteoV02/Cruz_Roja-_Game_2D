using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxFactor = 0.3f;

    private float initialY;
    private float initialCameraY;

    void Start()
    {
        initialY = transform.position.y;
        initialCameraY = cameraTransform.position.y;
    }

    void LateUpdate()
    {
        float deltaY = cameraTransform.position.y - initialCameraY;
        float newY = initialY + deltaY * parallaxFactor;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );
    }
}