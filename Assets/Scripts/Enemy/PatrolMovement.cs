using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour, IEnemyMovement
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2.0f;
    private CharacterController characterController;
    public Vector3 movementSpeed;
  

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        movementSpeed = direction.normalized * speed * Time.deltaTime;
        
        characterController.Move(movementSpeed);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}