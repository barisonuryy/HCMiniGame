using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement _playerMovement;
    private Animator animator;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void OnAnimatorMove()
    {
        animator.SetFloat("Speed",new Vector2(_playerMovement.movement.x,_playerMovement.movement.z).magnitude);
    }
}
