using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyblock : MonoBehaviour
{
    public bool madeonepass;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 position;
    public float speed = 1;
    //WARNING: speed can only be a mutiple of 1/4 or 1/8

    
    public bool xpos; 
    public bool xneg;
    public bool up;
    public bool down;
    public bool zpos;
    public bool zneg;

    private bool xposenebled = false; 
    private bool xnegenebled = false;
    private bool upenebled = false;
    private bool downenebled = false;
    private bool zposenebled = false;
    private bool znegenebled = false;

    void Start()
    {
        transform.localPosition = pos1;
        if(xpos)
        {
            xposenebled = true;
        }
        if(xneg)
        {
            xnegenebled = true;
        }
        if(up)
        {
            upenebled = true;
        }
        if(down)
        {
            downenebled = true;
        }
        if(zpos)
        {
            zposenebled = true;
        }
        if(zneg)
        {
            znegenebled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if(Time.timeScale == 1f)
        {
            {
            if (xpos)
            {
                transform.Translate(Vector3.right * speed);
            }
            if (xneg)
            {
                transform.Translate(Vector3.left * speed);
            }
            if (up)
            {
                transform.Translate(Vector3.up * speed);
            }
            if (down)
            {
                transform.Translate(Vector3.down * speed);
            }
            if (zpos)
            {
                transform.Translate(Vector3.forward * speed);
            }
            if (zneg)
            {
                transform.Translate(Vector3.back * speed);
            }
            //xpos
            if(xposenebled)
            {
            if (position == pos2 && xpos == true)
            {
                xpos = false;
                xneg = true;
                madeonepass = true;
            }
            if (position == pos1 && xneg == true && madeonepass == true)
            {
                xpos = true;
                xneg = false;
            }
            }
            //xneg
            if(xnegenebled)
            {
            if (position == pos2 && xneg == true)
            {
                xpos = true;
                xneg = false;
                madeonepass = true;
            }
            if (position == pos1 && xpos == true && madeonepass == true)
            {
                xpos = false;
                xneg = true;
            }
            }
            //down
            if(downenebled)
            {
            if (position == pos2 && down == true)
            {
                down = false;
                up = true;
                madeonepass = true;
            }
            if (position == pos1 && up == true && madeonepass == true)
            {
                up = false;
                down = true;
            }
            }
            //up
            if(upenebled)
            {
            if (position == pos2 && up == true)
            {
                up = false;
                down = true;
            }
            if (position == pos1 && down == true && madeonepass == true)
            {
                down = false;
                up = true;
            }
            }
            //zpos
            if(zposenebled)
            {
            if (position == pos2 && zpos == true)
            {
                zpos = false;
                zneg = true;
                madeonepass = true;
            }
            if (position == pos1 && zneg == true && madeonepass == true)
            {
                zneg = true;
                zpos = false;
            }
            }
            //zneg
            if(znegenebled)
            {
            if (position == pos2 && zneg == true)
            {
                zneg = false;
                zpos = true;
                madeonepass = true;
            }
            if (position == pos1 && zpos == true && madeonepass == true)
            {
                zpos = false;
                zneg = true;
            }
            }
        }
        }
    }
}
