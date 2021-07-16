using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlocktwo : MonoBehaviour
{
    public Vector3 pos1;
    //were the block starts
    public Vector3 pos2;
    //the blocks destination
    private Vector3 position;

    private bool madeonepass;

    private float Counter;

    public float speed;
    float test;
    GameObject Player;

    Rigidbodyscript Rbc;
    Rigidbody PlayerRigidbody;
    void Start()
    {
        transform.localPosition = pos1;
        Counter = 1;
        
        Player = GameObject.Find("Capsule");
        Rbc = Player.GetComponent<Rigidbodyscript>();
        PlayerRigidbody = Player.GetComponent<Rigidbody>();

    }
    void Update()
    {
        if(Time.timeScale == 1f)
        {
            position = transform.position;

            if(Counter == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2, speed);
            }
            if(Counter == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1, speed);
                madeonepass = true;
            }
            if(transform.position == pos2)
            {
                Counter = 2;
            }
            if(madeonepass == true && Counter == 2 && transform.position == pos1)
            {
                Counter = 1;
            }
        }
    }
    void FixedUpdate()
    {
        
        if(Rbc.isGrounded == false)
        {
            if(test >= 0)
            {
            PlayerRigidbody.velocity = new Vector3(-(speed * 100) + test + PlayerRigidbody.velocity.x, PlayerRigidbody.velocity.y, PlayerRigidbody.velocity.z);
            }
            if(test >= 1)
            {
            test = test - 0.1f;
            }
            if(test <= 1)
            {
            test = test - 0.01f;
            }
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
            Debug.Log("collided");
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
            Player = other.gameObject;
            test = speed * 100;
        }
    }
}

