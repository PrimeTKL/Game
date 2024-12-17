using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int destination = 0;

    public bool isChasing;
    public float chaseDistance;

    public bool isMoving = true;
    float speedRun;
    public Animator animator;
    public GameObject childObject;

    private Vector3 originalScale;

    private void Start()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
        if (childObject != null)
        {
            childObject.SetActive(false);
        }
        speedRun = moveSpeed;
    }

    private void Update()
    {
        if (!isMoving) return;

        bool isPlayerInRange = SkinPlayer.playerTransform != null && SkinPlayer.playerTransform.position.x > points[0].position.x && SkinPlayer.playerTransform.position.x < points[1].position.x;

        float distanceToPlayer = Vector2.Distance(transform.position, SkinPlayer.playerTransform.position);

        if (distanceToPlayer < chaseDistance || isPlayerInRange)
        {
            if (!isChasing)
            {
                originalScale = transform.localScale;
            }
            isChasing = true;
            animator.SetBool("Running", true);

            moveSpeed = speedRun + 2;
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
                animator.SetBool("Running", false);

                moveSpeed = speedRun;
                if (transform.localScale != originalScale)
                {
                    transform.localScale = originalScale;
                }

            }
            Patrol();
        }

        if (isChasing)
        {
            if (!isMoving) return;
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x > SkinPlayer.playerTransform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (transform.position.x < SkinPlayer.playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
