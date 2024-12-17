using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        checkpointPos = transform.position;
        if(playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    public void Die()
    {
        //StartCoroutine(Respawn(0.5f));
        //Respawn();
        Debug.Log("q");
        playerHealth.healthPl -= 5;

    }
    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }
    //IEnumerator Respawn(float duration)
    //{
    //    spriteRenderer.enabled = false;
    //    yield return new WaitForSeconds(duration);  
    //    transform.position = startPos;
    //    spriteRenderer.enabled = true;
    //}
     void Respawn()
     {
         transform.position = checkpointPos;
     }
}
