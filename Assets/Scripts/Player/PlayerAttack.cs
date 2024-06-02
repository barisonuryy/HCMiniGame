using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Character character;
    private AttackManager attackManager;
   
    private void Start()
    {
        
        attackManager = new AttackManager();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            attackManager.HandleAttack(character, other.GetComponent<Enemy>());
        }
            
    }
}
