using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSpike : MonoBehaviour
{
    //public Transform posA, posB;
    public float speed;
    Vector3 targetPos;

    MovementController movementController;
    Rigidbody2D rb;
    Vector3 moveDirection;

    Rigidbody2D playerRb;

    public GameObject ways;
    public Transform[] wayPoint;
    int pointIndex;
    int pointCount;
    int direction = 1;

    public float waiDuration;

    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        wayPoint = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoint[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    void Start()
    {
        pointIndex = 1;
        pointCount = wayPoint.Length;
        targetPos = wayPoint[1].transform.position;
        //targetPos = posB.position;    
        DirectionCalculate();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Vector2.Distance(transform.position,posA.position) < 0.05f)
        //{
        //    targetPos=posB.position;
        //    DirectionCalculate();
        //}
        //if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        //{
        //    targetPos = posA.position;
        //    DirectionCalculate();
        //}
        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            NextPoint();
        }
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
    private void NextPoint()
    {
        transform.position = targetPos;

        moveDirection = Vector3.zero;
        if (pointIndex == pointCount - 1)//
        {
            direction = -1;
        }
        if (pointIndex == 0)
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoint[pointIndex].transform.position;
        //DirectionCalculate();
        StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint()
    {
        yield return new WaitForSeconds(waiDuration);
        DirectionCalculate();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
    void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
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
            //playerRb.gravityScale = playerRb.gravityScale / 7;
        }
    }
}
