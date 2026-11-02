using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity = 1f;
    [SerializeField] private Transform cameraTransform;
    private Mouse _currentMouse = null;
    private float _xRotation = 0f;

    void Start()
    {
        _currentMouse = Mouse.current;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (_currentMouse == null)
            return;

        var mouseDelta = Mouse.current.delta.ReadValue();

        var mouseX = mouseDelta.x * MouseSensitivity;
        var mouseY = mouseDelta.y * MouseSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }
}
