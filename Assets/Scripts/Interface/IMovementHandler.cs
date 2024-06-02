using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementHandler
{
    void Move(CharacterController characterController, Vector2 movementInput, float moveSpeed);
}
