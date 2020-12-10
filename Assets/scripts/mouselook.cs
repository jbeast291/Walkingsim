using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=_QajrabyTJc video for full details

public class mouselook : MonoBehaviour {

    public float mouseSens = 100f;
    public Transform playerBody;    // inputs the game component's transform we want to change through the editor

    float xRotation = 0f;  // stores the change in rotation for the up and down looking (called xRotation b/c we're rotating around the x axis)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;     // gets mouse input
        playerBody.Rotate(Vector3.up * mouseX);                                   // rotates the player object by the amount of mouse input
        
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;     // gets mouse input
        xRotation -= mouseY;                                                      // increases rotation around x axis amount based on mouse input
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);            // rotating with quaternions instead of Rot
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

    }
}
