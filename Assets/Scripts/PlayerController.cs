using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private StatsManager _StatsManager;
    private Action doAction;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Camera mainCamera;
    private CameraFollow camFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
        rb.freezeRotation = true;
        _StatsManager = GetComponent<StatsManager>();
        mainCamera = Camera.main;
        camFollow = mainCamera.GetComponent<CameraFollow>(); // get camera follow script

        setActionVoid();
    }

    private void doActionVoid()
    {
        Move();
        Look();
        if (camFollow != null)
        camFollow.LookInput = lookInput;
    }

    private void setActionVoid()
    {
        doAction = doActionVoid;
    }

    void FixedUpdate()
    {
        doAction?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 camForward = mainCamera.transform.forward;
            Vector3 camRight = mainCamera.transform.right;
            camForward.y = camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * direction.z + camRight * direction.x;
            rb.MovePosition(rb.position + moveDir * _StatsManager.GetStat(Stat.MOVEMENT_SPEED) * Time.fixedDeltaTime);
        }
    }

    private void Look()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (direction.sqrMagnitude > 0.1f)
        {
            Vector3 camForward = mainCamera.transform.forward;
            Vector3 camRight = mainCamera.transform.right;
            camForward.y = camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * direction.z + camRight * direction.x;
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
