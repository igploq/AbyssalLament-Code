using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    public float tiltAmount = 10f; 
    public float tiltSpeed = 5f;  

    float cameraVerticalRotation = 0f;
    float currentTilt = 0f; 

    bool lockedCursor = true;

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation + Vector3.forward * currentTilt;

        
        player.Rotate(Vector3.up * inputX);

        
        float targetTilt = 0f;
        if (Input.GetKey(KeyCode.A)) targetTilt = tiltAmount; 
        if (Input.GetKey(KeyCode.D)) targetTilt = -tiltAmount; 

       
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, tiltSpeed * Time.deltaTime);
    }

    
}