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

    GameObject Player;
    void Start()
    {
        transform.localPosition = pos1;
        Counter = 1;
        Player = GameObject.Find("Player2.0");
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
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("test");
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
            Debug.Log(Vector3.RotateTowards(transform.forward, pos2, Mathf.PI * 2, 0.0f));
            other.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 100 , ForceMode.VelocityChange);
            
        }
    }
}
