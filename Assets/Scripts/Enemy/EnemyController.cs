using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IEnemyMovement enemyMovement;
    private IEnemyRotation enemyRotation;

    void Start()
    {
        enemyMovement = GetComponent<IEnemyMovement>();
        enemyRotation = GetComponent<IEnemyRotation>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (enemyMovement != null)
        {
            Vector3 currentPos = transform.position;
            enemyMovement.Move();
            direction = transform.position - currentPos;
        }

        if (enemyRotation != null && direction.sqrMagnitude > 0)
        {
            enemyRotation.Rotate(direction);
        }
    }
}
