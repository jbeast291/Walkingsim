using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbodyscript : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _camera;

    public float moveSpeed = 6f;
    public float BaseMoveSpeed = 6f;
    public float jumpForce = 10f;
    public float jumpPadForce = 30f;
    public float SpeedPadMulti = 10f;
    float Speedcounter = 1f;

    public LayerMask Ground;
    public LayerMask Jumppad;
    public LayerMask SpeedPad;
    public LayerMask VisablePad;
    public LayerMask VisablePadground;


    bool isGrounded;
    bool isonjumppad;
    bool isOnSpeedpad;
    bool isonVisablePad;
    bool isonVisablePadground;
    bool Hitbox;

    public AudioSource jumppadsound;
    public AudioSource SpeedPadSoundStart;
    public AudioSource SpeedPadSoundEnd;
    public AudioSource jump;

    void Start()
    {
        Time.timeScale = 1f;
        //BoxCollider Hitbox = gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {


        //grounding
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, Ground);
        
        //if you are on jumppad
        isonjumppad = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, Jumppad);

        //If you are on speedpad
        isOnSpeedpad = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, SpeedPad);

        //if you are on Visable Pad
        isonVisablePad = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, VisablePad);

        //if you are on Visable Pad ground
        isonVisablePadground = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, VisablePadground);


        //if you are on a wall
        Hitbox = Physics.CheckBox(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),new Vector3(0.8f, 0.8f, 0.8f), Quaternion.identity, Ground);

        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

        //moving
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;



        Vector3 move = transform.right * x + transform.forward * y;

        //Audio
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnSpeedpad)
        {
            jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isonVisablePad)
        {
            jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isonVisablePadground)
        {
            jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isonjumppad)
        {
            jumppadsound.Play();
        }
        if (isOnSpeedpad && Speedcounter == 1 && isGrounded == false)
        {
            Speedcounter = 0;
            SpeedPadSoundStart.Play();
        }
        if (isGrounded && Speedcounter == 0 && isOnSpeedpad == false)
        {
            Speedcounter = 1;
            SpeedPadSoundEnd.Play();
        }



        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);


        //Speed pad jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnSpeedpad)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //Visable pad jumping
        if (Input.GetKeyDown(KeyCode.Space) && isonVisablePad)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //Visable ground jumping
        if (Input.GetKeyDown(KeyCode.Space) && isonVisablePadground)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //jump pad
        if (Input.GetKeyDown(KeyCode.Space) && isonjumppad)
            rb.velocity = new Vector3(rb.velocity.x, jumpPadForce, rb.velocity.z);

        //speed pad
        if (isOnSpeedpad)
            moveSpeed = SpeedPadMulti;

        if (isGrounded)

            moveSpeed = BaseMoveSpeed;
        //setting movement

        rb.velocity = new Vector3(move.x, rb.velocity.y,move.z);

        //making it so you can wall climb
        if (isGrounded == false && Hitbox == true)
        {
            rb.velocity = new Vector3(0,-25,0);
        }
    }
}