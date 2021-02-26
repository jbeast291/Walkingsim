using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.audio;

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
    public LayerMask GroundPadMask;//used to check if the player is standing on a speed pad

    public float SpeedMod = 3f;//speed pad multiplier
    public LayerMask SpeedPadMask;//used to check if the player is on the speed pad

    public LayerMask VisiblePadMask;

    public LayerMask invisableBlockMask;

    public LayerMask THICKPADMASK;

    bool isOnJumpPad;// a boolian to check if the player is on a jump pad
    bool isGrounded;// a boolian to check if the player is on the ground
    bool isOnSpeedPad;// a boolian to check if the player is on a speed pad
    bool issped;// a boolian to see if the player hasnt touch the ground so they are able to move fast still
    public bool isOnVisiblePad;
    public bool invisableBlock;
    bool isonTHICKPAD;

    int SpeedCounter = 0;
    bool PadSoundLoop;

    public AudioSource jumppadsound;
    public AudioSource SpeedPadSoundStart;
    public AudioSource SpeedPadSoundEnd;
    public AudioSource jump;

    //public
    Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: fix the bug were the player cant jump over the wall if they are on a corner :-(
        //

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);// bool for checking if the player is grounded
        isOnJumpPad = Physics.CheckSphere(groundCheck.position, groundDistance, GroundPadMask);// bool for checking if the player is on a jump pad
        isOnSpeedPad = Physics.CheckSphere(groundCheck.position, groundDistance, SpeedPadMask);// bool for checking if the player is on a speed pad
        isOnVisiblePad = Physics.CheckSphere(groundCheck.position, groundDistance, VisiblePadMask);
        invisableBlock = Physics.CheckSphere(groundCheck.position, groundDistance, invisableBlockMask);
        isonTHICKPAD = Physics.CheckSphere(groundCheck.position, groundDistance, THICKPADMASK);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(isOnJumpPad && velocity.y < 0)
        {
            velocity.y = -2f;
        } 
        if(isOnSpeedPad && velocity.y < 0)
        {
            velocity.y = -2f;
        } 
        if(isOnVisiblePad && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(invisableBlock && velocity.y < 0)
        {
            velocity.y = -2f;
        }  
        if(isonTHICKPAD && velocity.y < 0)
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

        if(isOnSpeedPad)
        {
            if(SpeedCounter == 0)
            {
                SpeedPadSoundStart.Play();
                SpeedCounter = 1;
            }

        }
        if(isOnSpeedPad == false && SpeedCounter == 1 && issped == false)
        {
            SpeedPadSoundEnd.Play();
            SpeedCounter = 0;
        }
        // Ctrl + K, Ctrl + C = comments out a block of code


        


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
            if(isOnVisiblePad)
            {
                jump.Play();
            }
            if(invisableBlock)
            {
                jump.Play();
            }
            if(isonTHICKPAD)
            {
                jump.Play();
            }
        }

        if(Input.GetButtonDown("Jump") && isOnJumpPad)// make the player do a higher jump if they are on a pad
        {
            velocity.y = Mathf.Sqrt(jumpPadForce * -2f * gravity);

        }
        if(isOnVisiblePad && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }
        if(invisableBlock && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }
        if(isonTHICKPAD && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
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
        


        if(Input.GetKeyDown(KeyCode.K))
        {
            transform.localScale = new Vector3(1,1,1);
            GameObject Fps_Player = GameObject.Find("fps player");
            GameObject Capsule = Fps_Player.transform.GetChild(1).gameObject;
            Capsule.transform.localPosition = new Vector3(0,0,0);

            GameObject Camera = Fps_Player.transform.GetChild(0).gameObject;
            Camera.transform.localPosition = new Vector3(0.15f,3.38f,-4.59f);

        }
        if(isonTHICKPAD)
        {
            transform.localScale = new Vector3(3,0.5f,3);

            GameObject Fps_Player = GameObject.Find("fps player");
            GameObject Capsule = Fps_Player.transform.GetChild(1).gameObject;
            Capsule.transform.localPosition = new Vector3(0,-2.25f,0);

            GameObject GroundCheckObject = Fps_Player.transform.GetChild(2).gameObject;
            GroundCheckObject.transform.localPosition = new Vector3(0,-3,0);

            GameObject Camera = Fps_Player.transform.GetChild(0).gameObject;
            Camera.transform.localPosition = new Vector3(0,9,-1.5f);


        
        }


    }
}
