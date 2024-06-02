using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : IRotationHandler
{
    public void Rotate(Transform transform, Vector2 lookInput, float rotationSpeed, float deltaTime)
    {
        if (lookInput != Vector2.zero)
        {
            Vector3 direction = new Vector3(lookInput.x, 0, lookInput.y);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * deltaTime);
        }
    }
}