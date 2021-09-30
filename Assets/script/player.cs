using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] float rollForce = 6.5f;
    [SerializeField] float movementX;

    private Sensor_HeroKnight m_groundSensor;
    private Animator animator;
    private Rigidbody2D body2d;
    private SpriteRenderer sr;
    private string RUN_ANIMATION = "Run";
    private bool m_FacingRight = true;
    private bool grounded = true;
    private bool rolling = false;
    private float rollDuration = 8.0f / 14.0f;
    private float rollCurrentTime;
    private float delayToldle = 0.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //animator.SetFloat("AirSpeedY", body2d.velocity.y);
        //m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
    }
    // Start is called before the first frame update
    void Start()
    {
         

    }

    // Update is called once per frame
    void Update()
    {

        PlayerCrouch();
        PlayerMoveKeyboard();
        if(movementX > 0 && !m_FacingRight)
        {
            
            Flip();
        }
        else if (movementX < 0 && m_FacingRight)
        {
            
            Flip();
        }
        RunAnim();


        //check player touch the ground
        /*if (grounded && m_groundSensor.State())
        {
            grounded = true;
            animator.SetBool("Ground", grounded);
        }*/

        //Check if player is falling
        /*if(grounded && !m_groundSensor.State())
        {
            grounded = false;
            animator.SetBool("Ground", grounded);
        }*/

        PlayerJump();
        //Idle();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveSpeed;
        /*float movementX = Input.GetAxis("Horizontal");
        if (Mathf.Abs(movementX) > Mathf.Epsilon)
        {
            delayToldle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }*/
    }

    /*void Idle()
    {
        delayToldle -= Time.deltaTime;
        if (delayToldle < 0)
            animator.SetInteger("AnimState", 0);
    }*/
    
   
    void RunAnim()
    {
        if (movementX > 0)
        {
            Debug.Log("right");
            animator.SetBool(RUN_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            Debug.Log("left");
            animator.SetBool(RUN_ANIMATION, true);
        }
        else
        {
            animator.SetBool(RUN_ANIMATION, false);
        }
    }
    void Flip()
    {
        //sprite facing direction when move       
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) /*&& grounded*/ && !rolling)
        {
            
            animator.SetBool("Jump", true);
            //grounded = false;
            //animator.SetBool("Ground", grounded);
            Debug.Log("Jump pressed");
            //body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
            body2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //m_groundSensor.Disable(0.2f);
        }
    }

    void PlayerCrouch()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("Crouch", true);
            Debug.Log("Crouching");
        }else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Crouch", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
        
    }
}
