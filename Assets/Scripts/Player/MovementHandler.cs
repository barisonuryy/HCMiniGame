using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : IMovementHandler
{
    public void Move(CharacterController characterController, Vector2 movementInput, float moveSpeed)
    {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed * Time.deltaTime;
        characterController.Move(move);
    }
}
