using UnityEngine;

public class MovementController : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float direction = 0f;

    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private float moveSpeed = 7f;

    [SerializeField]
    private float jumpSpeed = 14f;

    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump")&& IsGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, .1f,groundLayers);
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
