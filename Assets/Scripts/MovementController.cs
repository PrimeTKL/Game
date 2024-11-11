using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    InputSystem controls;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator;


    public bool isOnPlatform;
    public Rigidbody2D platFormRb;

    public CoinManager cm;
    

    private float direction = 0f;

    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private float moveSpeed = 7f;

    [SerializeField]
    private float jumpSpeed = 14f;
    
    //private enum StateAnimation { idle, run, jump, fall};

    bool isGrounded;


    private void Awake()
    {
        controls = new InputSystem();
        controls.Player.Movement.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Player.Movement.canceled += ctx =>
        {
            direction = 0f;
        };
        controls.Player.Jump.performed += ctx => Jump();

        controls.Player.Attack.performed += ctx => StartAttack();
        controls.Player.Attack.canceled += ctx => StopAttack();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        //direction = Input.GetAxisRaw("Horizontal");
        if (isOnPlatform)
        {
            rb.velocity = new Vector2((direction * moveSpeed) + platFormRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        //rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpSpeed);
        }
        //StateAnimation state;

        if (direction > 0f)
        {
            animator.SetBool("isRunning", true);
            //state=StateAnimation.run;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0f)
        {
            animator.SetBool("isRunning", true);
            //state = StateAnimation.run;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("isRunning", false);
            //state = StateAnimation.idle;
        }
        if(rb.velocity.y > .1f)
        {
             animator.SetBool("isJumping", true);
            //state = StateAnimation.jump;

        }
        else if(rb.velocity.y < .1f)
        {
            animator.SetBool("isJumping", false);
           // state = StateAnimation.fall;
        }
        // animator.SetInteger("state",(int)state);


    }
    private void StartAttack()
    {
        
        animator.SetBool("isAttacking", true);
    }

    private void StopAttack()
    {
        
        animator.SetBool("isAttacking", false);
    }

    void Jump()
    {
        if(IsGrounded())
        {
            rb.velocity=new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, .1f,groundLayers);
    }
    void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
    //    Rigidbody2D rb;

    //    [SerializeField] int speed;
    //    float speedMultiplier;

    //    //he so gia toc
    //    [Range(0, 10)]
    //    [SerializeField] float acceleration;

    //    private Animator animator=null;

    //    bool btnPressed;

    //    private void Awake()
    //    {
    //        rb = GetComponent<Rigidbody2D>();
    //        animator = GetComponent<Animator>();
    //    }

    //    private void FixedUpdate()
    //    {
    //        UpdateSpeedMultiplier();
    //        float targetSpeed = speed * speedMultiplier;

    //        rb.velocity=new Vector2 (targetSpeed,rb.velocity.y);
    //    }

    //    public void Move(InputAction.CallbackContext value)
    //    {
    //        if (value.started) { 
    //            btnPressed = true;
    //            //speedMultiplier = 1;
    //            animator.SetBool("isRunning", true);
    //        }
    //        else if(value.canceled) { 
    //            btnPressed = false;
    //            //speedMultiplier = 0;
    //            animator.SetBool("isRunning",false);
    //        }
    //    }
    //    void UpdateSpeedMultiplier()
    //    {
    //        if (btnPressed && speedMultiplier <1)
    //        {
    //            speedMultiplier += Time.deltaTime*acceleration;
    //        }
    //        else if(!btnPressed && speedMultiplier >0)
    //        {
    //            speedMultiplier-= Time.deltaTime*acceleration;
    //            if (speedMultiplier < 0)
    //            {
    //                speedMultiplier=0;
    //            }
    //        }
    //    }    
}
