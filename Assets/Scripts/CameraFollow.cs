using UnityEngine;

/// <summary>
/// Third-person camera that follows the player
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform target;
    
    [Header("Camera Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 8f, -10f);
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private float lookAheadDistance = 2f;
    
    void LateUpdate()
    {
        if (target == null)
        {
            // Try to find player if target is not set
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            return;
        }
        
        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly interpolate to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Look at target with slight forward offset
        Vector3 lookAtPosition = target.position + target.forward * lookAheadDistance;
        transform.LookAt(lookAtPosition);
    }
}
