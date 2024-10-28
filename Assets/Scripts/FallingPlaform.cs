using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlaform : MonoBehaviour
{
    private float fallDelay = 0.5f;
    private float destroyDelay = 1f;

    MovementController movementController;
    
    Vector3 moveDirection;
    Rigidbody2D playerRb;

    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject,destroyDelay);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = true;
            movementController.platFormRb = rb;

            //playerRb.gravityScale = playerRb.gravityScale * 7;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = false;
           // playerRb.gravityScale = playerRb.gravityScale / 7;
        }
    }
}
