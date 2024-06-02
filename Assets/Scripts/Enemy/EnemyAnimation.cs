using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    
    private Animator animator;
    private PatrolMovement patrolMovement;
    void Start()
    {
        patrolMovement = GetComponent<PatrolMovement>();
        animator = GetComponent<Animator>();

    }

 

    // Update is called once per frame
    private void OnAnimatorMove()
    {
        if(GetComponent<PatrolMovement>()!=null)
        animator.SetFloat("Speed",patrolMovement.movementSpeed.magnitude);
    }
}
