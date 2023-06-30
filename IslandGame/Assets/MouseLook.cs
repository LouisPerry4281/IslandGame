using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float mouseSensitivity = 100f;
    float xRotation = 0f;

    [Header("References")]
    [SerializeField] Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
