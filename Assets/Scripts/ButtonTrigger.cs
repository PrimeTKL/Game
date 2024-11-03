using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public HingeJoint2D lever;

    public Sprite newSprite;  
    private SpriteRenderer spriteRenderer;

    private bool isActivated = false; 

    void Start()
    {
        if (lever != null)
        {
            lever.useMotor = false;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true; 
            ActivateLever();

            ChangeSprite();
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
    private void ChangeSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;  
        }
    }
}
