using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstpersoncamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private bool lockCursor = true;

    private float cameraPitch = 0.0f;
    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        UpdateMouseLook();
    }

    void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x, mouseSensitivity);

    }
}
