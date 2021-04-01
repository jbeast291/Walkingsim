using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool button1var;
    public bool button2var;
    bool dooractivated = false;

    void Update()
    {
        if(button1var == true && button2var == true && dooractivated == false)
        {
            dooractivated = true;
            transform.Translate(Vector3.up * 10);
        }
    }

    public void button1()
    {
        button1var = true;
    }

    public void button2()
    {
        button2var = true;
    }
}
