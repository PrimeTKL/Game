using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public HingeJoint2D lever;
<<<<<<< HEAD

    public Sprite newSprite;  
    private SpriteRenderer spriteRenderer;

=======
>>>>>>> 4014effcc988a92c527568d2cd47dbe1e6cf6c2a
    private bool isActivated = false; 

    void Start()
    {
        if (lever != null)
        {
            lever.useMotor = false;
        }
<<<<<<< HEAD

        spriteRenderer = GetComponent<SpriteRenderer>();
=======
>>>>>>> 4014effcc988a92c527568d2cd47dbe1e6cf6c2a
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true; 
<<<<<<< HEAD
            ActivateLever();

            ChangeSprite();
=======
            ActivateLever(); 
>>>>>>> 4014effcc988a92c527568d2cd47dbe1e6cf6c2a
        }
    }

    private void ActivateLever()
    {
        if (lever != null)
        {
            lever.useMotor = true; 

           
            lever.useLimits = true;
        }
    }
<<<<<<< HEAD
    private void ChangeSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;  
        }
    }
=======
>>>>>>> 4014effcc988a92c527568d2cd47dbe1e6cf6c2a
}
