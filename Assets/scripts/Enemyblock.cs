using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyblock : MonoBehaviour
{
    public float myTime;
    bool position = false;
    void Start()
    {
        myTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= myTime + 1.0f)
        {
            position = !position;
            myTime = Time.time;
        }
        if(position == true)
        {
            transform.Translate(Vector3.left * 1.25f);
        }
        else if(position == false) 
        {
            transform.Translate(Vector3.right * 1.25f);
        }
        Debug.Log(position);

        
    }
}
