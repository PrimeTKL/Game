using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int destination = 0; 

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public bool isMoving = true;

    public Animator animator;
    public GameObject childObject;

    public PlayerHealth playerHealth;

    private Vector3 originalScale;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
        originalScale = transform.localScale;

        if (childObject != null)
        {
            childObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isMoving) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < chaseDistance && playerHealth.healthPl > 0)
        {
            if (!isChasing)
            {
                originalScale = transform.localScale; 
            }
            isChasing = true;
            animator.SetBool("Bite", true);

            if (childObject != null)
            {
                childObject.SetActive(true);
            }
        }
        else
        {
            if (isChasing) 
            {
                isChasing = false;
                animator.SetBool("Bite", false);
            
                if (transform.localScale != originalScale)
                {
                    transform.localScale = originalScale;
                }
            }
            Patrol();

            //if (childObject != null)
            //{
            //    childObject.SetActive(false);
            //}
        }

        if (isChasing)
        {
            if (!isMoving) return;
            ChasePlayer(); 
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    private void Patrol()
    {
        if (destination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[0].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                destination = 1;
            }
        }
        else if (destination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                destination = 0;
            }
        }
    }

    public void SetMovement(bool move)
    {
        isMoving = move;
    }
}
