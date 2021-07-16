using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock3 : MonoBehaviour
{
    Rigidbody r;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        r = this.GetComponent<Rigidbody>();
        r.AddForce(-10,0,0, ForceMode.Force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        r.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
        //r.AddForce(-1,0,0, ForceMode.Force);
    }
}
