using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensivity;

    private float xRotation = 0f;

    [SerializeField]
    private Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime; //horizontal axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime; //vertical axis

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //vertical rotation clamp between -90 degrees and 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //vertical rotation
        playerBody.Rotate(Vector3.up * mouseX); //horizontal rotation
    }
}
