using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbodyscript : MonoBehaviour
{

    public Rigidbody RigidbodyVar;
    public float MaxSpeed;
    public float JumpForce;
    public bool canjump;


    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (RigidbodyVar.velocity.z < MaxSpeed)
            {
                RigidbodyVar.AddForce(RigidbodyVar.transform.forward * MaxSpeed, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (RigidbodyVar.velocity.z < MaxSpeed)
            {
                RigidbodyVar.AddForce(RigidbodyVar.transform.forward * -MaxSpeed, ForceMode.VelocityChange);
            }
        }
    }
    //void MaxSpeedClamp()
    //{
    //    if (!Input.GetKeyDown(KeyCode.D))
    //}

    
}
