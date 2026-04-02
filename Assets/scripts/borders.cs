using UnityEngine;

public class PerspectiveCameraFollow : MonoBehaviour
{
    [Header("Target & Smooth Follow")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10); // Default offset
    public float smoothSpeed = 5f;

    [Header("Camera Bounds (World Coordinates)")]
    private float minX = 40f;
    private float maxX = 345f;
    private float minY = 20f;
    private float maxY = 170f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position
        Vector3 desiredPosition = target.position + offset;

        // Calculate visible camera half-size at target depth
        float distance = Mathf.Abs(transform.position.z - target.position.z);
        float halfHeight = Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * distance;
        float halfWidth = halfHeight * cam.aspect;

        // Clamp the camera so it never goes outside level bounds
        float clampX = Mathf.Clamp(desiredPosition.x, minX + halfWidth, maxX - halfWidth);
        float clampY = Mathf.Clamp(desiredPosition.y, minY + halfHeight, maxY - halfHeight);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        // Smoothly move camera
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
    }
}