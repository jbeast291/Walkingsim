using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlocktwo : MonoBehaviour
{
    public Vector3 pos1;
    //were the block starts
    public Vector3 pos2;
    //the blocks destination
    public Vector3 pos3;
    private bool madeonepass;

    private float Counter;

    public float speed;
    void Start()
    {
        transform.localPosition = pos1;
        Counter = 1;
        

    }
    void Update()
    {
        if(Time.timeScale == 1f)
        {

            if(Counter == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2, speed);
            }
            if(Counter == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos3, speed);
                madeonepass = false;
            }
            if(Counter == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1, speed);
            }
            if(transform.position == pos2)
            {
                Counter = 2;
            }
            if(transform.position == pos3 && madeonepass == false)
            {
                Counter = 1;
                madeonepass = true;
            }
            if(transform.position == pos2 && madeonepass == true)
            {
                Counter = 3;
            }
            if(transform.position == pos1 && madeonepass == true)
            {
                Counter = 1;
                madeonepass = false;
            }
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

