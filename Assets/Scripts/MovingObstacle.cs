using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingObstacle : MonoBehaviour
{
    public float speed=5f;
    Vector3 targetPos;

    

    public GameObject ways;
    public Transform[] wayPoint;
    int pointIndex;
    int pointCount;
    int direction = 1;

    private void Awake()
    {
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
        targetPos = wayPoint[pointIndex].transform.position;
        
    }
    void Update()
    {
        var step=speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position==targetPos)
        {
            NextPoint();
        }
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
    private void NextPoint()
    {
        
        
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
        
    }
 
}
