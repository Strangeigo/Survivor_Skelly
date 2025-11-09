using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private Vector2 sensitivity = new Vector2(100f, 50f);
    [SerializeField] private Vector2 pitchLimits = new Vector2(-30f, 60f);
    [SerializeField] private float distance = 5f;

    private float yaw;
    private float pitch;

    public Vector2 LookInput { get; set; }

    void LateUpdate()
    {
        if (target == null) return;

        // Rotate based on input
        yaw += LookInput.x * sensitivity.x * Time.deltaTime;
        pitch -= LookInput.y * sensitivity.y * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        // Apply rotation to camera position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);

        transform.position = target.position + offset + Vector3.up * 1.5f;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
