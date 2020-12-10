using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.audio;
//hello
public class playermovent : MonoBehaviour
{
    
    public CharacterController controller;// character controller
    public float runSpeed = 12f;// run speed of the player
    public float gravity = -9.81f;// how much gravity there is 
    public float jumpHeight = 3f;// the hight of the jump
    public Transform groundCheck;//used to check if the player is on he ground
    public float groundDistance = 0.4f;//used to check the distance to the ground
    public LayerMask groundMask;// checks if the player is standing on the ground

    public float jumpPadForce = 10f;//the force of the sjumppad
    public Transform padCheck;//used to check if the player is on a jump pad
    public float groundDistanceToPad = 0.4f;//checks the distance to a jump pad
    public LayerMask GroundPadMask;//used to check if the player is standing on a speed pad

    public float SpeedMod = 3f;//speed pad multiplier
    public Transform speedPadCheck;//used to check if the player is on a speed pad
    public float SpeedpadDistance = 0.4f;//used to check the distance to a speed pad
    public LayerMask SpeedPadMask;//used to check if the player is on the speed pad

    bool isOnJumpPad;// a boolian to check if the player is on a jump pad
    bool isGrounded;// a boolian to check if the player is on the ground
    bool isOnSpeedPad;// a boolian to check if the player is on a speed pad
    bool issped;// a boolian to see if the player hasnt touch the ground so they are able to move fast still

    public AudioSource jumppadsound;
    public AudioSource SpeedPadSoundStart;
    public AudioSource jump;
    //public
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: fix the bug were the player cant jump over the wall if they are on a corner
        //TODO: the player will gain infinite velocity if standing on a speed pad and not on a ground
        //

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);// bool for checking if the player is grounded
        isOnJumpPad = Physics.CheckSphere(padCheck.position, groundDistanceToPad, GroundPadMask);// bool for checking if the player is on a jump pad
        isOnSpeedPad = Physics.CheckSphere(speedPadCheck.position, SpeedpadDistance, SpeedPadMask);// bool for checking if the player is on a speed pad

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");// gets the x Axis
        float z = Input.GetAxis("Vertical");// gets the y Axis

        Vector3 move = transform.right * x + transform.forward * z;// makes a vector3 for the movement code
        

        if(Input.GetButtonDown("Jump") && isGrounded)// makes the player jump if they are on the ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //if(isOnSpeedPad)
        //{
        //SpeedPadSoundStart.Play();

        //}
        


        if(Input.GetButtonDown("Jump"))//for sounds
        {
            if(isOnJumpPad)//if on the jump pad it wont play the jump sound and only the jump pad
            {
                jumppadsound.Play();
            }
            if(isGrounded && isOnJumpPad == false)//if its not on the jump pad then it will play the jump sound
            {
                jump.Play();
            }
            if(isOnSpeedPad)
            {
                jump.Play();
            }
        }

        if(Input.GetButtonDown("Jump") && isOnJumpPad)// make the player do a higher jump if they are on a pad
        {
            velocity.y = Mathf.Sqrt(jumpPadForce * -2f * gravity);

        }

        if(isOnSpeedPad)// if the player is on the speed pad it will set issped to true and make the player run faster
        {
            if(Input.GetButtonDown("Jump"))//allows the player to jump if they are on a speed pad
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            issped = true;
            controller.Move(move * runSpeed * SpeedMod * Time.deltaTime);// mulitplies speedmod with the movement code to run faster
        }
        else if(isGrounded == false && issped)//allows the player to keep the velocity of the speed pad when jumping 
        {
            controller.Move(move * runSpeed * SpeedMod * Time.deltaTime);
        }
        else// makes the player move at normal speed and sets issped to false
        {
            issped = false;// sets issped to false so the player dosent move fast in the air 
            controller.Move(move * runSpeed * Time.deltaTime);
        }    
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
