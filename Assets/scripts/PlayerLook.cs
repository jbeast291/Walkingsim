using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 10;

    float x = 0;
    float y = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //input
        x += -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //clamping
        x = Mathf.Clamp(x, -60, 60);

        //rotation
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}