using System;
using UnityEngine;

public class CharacterFollowUI : MonoBehaviour
{
    public Transform character; 
    public Vector3 offset;



    private void Awake()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void LateUpdate()
    {
        if (character != null)
        {
        
            Vector3 worldPosition = character.position + offset;
            transform.position = worldPosition;
            

        }
    }
}
