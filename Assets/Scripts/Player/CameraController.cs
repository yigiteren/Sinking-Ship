using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float lookSensitivity = 200f;
    [SerializeField] [Range(0,90)]
    float lookDownLimit = 90.0f;
    [SerializeField] [Range(0,90)]
    float lookUpLimit = 90.0f;
    [SerializeField]
    Transform player = null;

    float upDownRotation = 0;
    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        RightLeftLook(); //Rotates player body
        UpDownLook(); // Rotates camera
    }

    void RightLeftLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        player.Rotate(Vector3.up * mouseX); // Rotates body
    }

    void UpDownLook()
    {
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        
        upDownRotation -= mouseY; //Make the '-' -> '+' for inverse look
        upDownRotation = Mathf.Clamp(upDownRotation, -lookUpLimit, lookDownLimit);

        transform.localRotation = Quaternion.Euler(upDownRotation, 0f, 0f); // Rotate camera
    }
}
