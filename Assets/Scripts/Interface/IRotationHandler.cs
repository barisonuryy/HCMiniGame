
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotationHandler
{
    void Rotate(Transform transform, Vector2 lookInput, float rotationSpeed, float deltaTime);
}
