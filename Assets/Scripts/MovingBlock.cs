using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private Vector3 pointA; 
    private Vector3 pointB; 
    private float minSpeed = 0.5f; 
    public float maxSpeed = 2.0f; 

    private bool isMovingToA = true;
    private float currentSpeed;
    void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();
        List<Vector3> points = player.GetMovingPoints(transform.position.z);
        pointA = points[0];
        pointB = points[1];
    }

    void Update()
    {
        if (isMovingToA)
        {
            MoveTowards(pointA);
        }
        else
        {
            MoveTowards(pointB);
        }
    }

    void MoveTowards(Vector3 target)
    {
        float step = currentSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isMovingToA = !isMovingToA;
        }
    }
}
