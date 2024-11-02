using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public HingeJoint2D lever;
    private bool isActivated = false; 

    void Start()
    {
        if (lever != null)
        {
            lever.useMotor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true; 
            ActivateLever(); 
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
}
