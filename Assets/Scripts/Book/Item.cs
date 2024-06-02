using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int experiencePoints = 10; 

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            CharacterLevelManager.Instance.AddExperience(character, experiencePoints);
            Destroy(gameObject); 
        }
    }
}
