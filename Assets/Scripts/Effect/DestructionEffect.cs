using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionEffect : MonoBehaviour
{
    
    void Start()
    {
        
        var particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            Destroy(gameObject, particleSystem.main.duration);
        }
        else
        {
           
            Destroy(gameObject, 2.0f); 
        }
    }
}
