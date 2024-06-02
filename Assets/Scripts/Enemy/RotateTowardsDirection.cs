using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateTowardsDirection : MonoBehaviour, IEnemyRotation
{
    public float rotationSpeed = 5.0f;

    public void Rotate(Vector3 direction)
    {
        if (direction.sqrMagnitude == 0)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
