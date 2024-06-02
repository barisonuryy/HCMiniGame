using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager
{
    
    public void HandleAttack(Character character, Enemy enemy)
    {
        if (character.Level > enemy.Level)
        {
            character.Attack(enemy);
            enemy.GetComponent<IEnemy>().Die();
            enemy.Destroy();
        }
        else if (enemy.Level > character.Level)
        {
            enemy.Attack(character);
            character.Destroy();
        }
    }
}
