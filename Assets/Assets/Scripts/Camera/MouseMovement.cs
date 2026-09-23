using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Camera playerCamera;
    public float normalFov = 60f;
    public float zoomFov = 35f;
    public float zoomSpeed = 10f;

    float xRotation = 0f;
    float YRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (playerCamera == null)
        {
            playerCamera = GetComponent<Camera>();
        }

        if (playerCamera != null)
        {
            playerCamera.fieldOfView = normalFov;
        }
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        YRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

        if (playerCamera != null)
        {
            float targetFov = Input.GetMouseButton(1) ? zoomFov : normalFov;
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFov, Time.deltaTime * zoomSpeed);
        }
    }
}
