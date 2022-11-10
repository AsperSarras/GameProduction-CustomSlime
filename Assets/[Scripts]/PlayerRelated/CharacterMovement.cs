using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CharacterMovement : MonoBehaviour
{
    //Movement related
    public float speed;
    float hInput;
    public float vInput;

    public Transform orientation;

    Vector3 movementDir;

    //Ground check/Drag related
    public float groundDrag;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask whatIsGround;
    public bool grounded;

    //Jump Related
    public float jumpForec;
    public float airMult;
    public float jumpCd;
    bool canJump;
    public KeyCode jumpKey;


    Rigidbody rb;

    //
    public float xS;
    float xR;
    public float yS;
    float yR;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        canJump = true;

    }

    // Update is called once per frame
    void Update()
    { 

        //Check if it is Grounded
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);


        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        //transform.rotation = orientation.rotation;


        // Ground drag 
        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        { 
            rb.drag = 0; 
        }



    }

    private void FixedUpdate()
    {
        if(GameSingleton.Instance.isOnMenu == false)
        {
            Move();
            speedControl();
            Rotate();
            //Jump
            if (Input.GetKey(jumpKey) && canJump && grounded)
            {
                canJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCd);
            }
        }

    }

    private void Rotate()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mX = Input.GetAxisRaw("Mouse X") * xS * Time.deltaTime;
            float mY = Input.GetAxisRaw("Mouse Y") * yS * Time.deltaTime;

            xR -= mY;
            xR = Mathf.Clamp(xR, -45.0f, 45.0f);
            yR += mX;

            //rotate
            transform.rotation = Quaternion.Euler(xR, yR, 0);
        }
    }

    private void Move()
    {
        //Avoid flying if looking forwad.
        Vector3 forward = new Vector3(orientation.forward.x, 0, orientation.forward.z).normalized;
        movementDir = forward * vInput + orientation.right * hInput;


        if(grounded)
        {
            float fSpeed;
            if (vInput < 0)
            {
                fSpeed = speed * 0.075f;
            }
            else
            {
                fSpeed = speed;
            }
            rb.AddForce(movementDir.normalized * fSpeed * 10, ForceMode.Force);
        }
            
        else
            rb.AddForce(movementDir.normalized * speed * 10 * airMult, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForec, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        canJump = true;
    }
}

