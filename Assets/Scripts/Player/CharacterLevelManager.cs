using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelManager : MonoBehaviour
{
    public static CharacterLevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddExperience(Character character, int experiencePoints)
    {
        character.AddExperience(experiencePoints);
    }
}
