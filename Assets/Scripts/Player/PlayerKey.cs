using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    private HashSet<KeyType> collectedKeys = new HashSet<KeyType>();
    [SerializeField] private AnimationClip _animationClip;
    private void OnTriggerEnter(Collider other)
    {

        Key key = other.GetComponent<Key>();
        Board board = other.GetComponent<Board>();
        if (key != null)
        {
            collectedKeys.Add(key.keyType);
            key.GetComponent<Animator>().enabled = true;
            Destroy(other.gameObject,_animationClip.length/1.3f);
            
        }

        if (board != null && board.allDie)
        {
            StartDoorBoardOscillation(board);
        }

        
        Door door = other.gameObject.GetComponent<Door>();
        if (door != null && door.IsUnlocked())
        {
            StartDoorOscillation(door);
        }
       
        else if (door != null)
        {
            if (collectedKeys.Contains(door.requiredKeyType))
            {
                if (door.TryUnlock(door.requiredKeyType))
                {
                    collectedKeys.Remove(door.requiredKeyType);
                    StartDoorOscillation(door);
                }
            }
        }
    }

    private void StartDoorOscillation(Door door)
    {
        DoorOscillation[] doorOscillations = door.GetComponentsInChildren<DoorOscillation>();
        foreach (var doorOscillation in doorOscillations)
        {
            doorOscillation.StartOscillation();
        }
    }
    private void StartDoorBoardOscillation(Board board)
    {
        DoorOscillation[] doorOscillations = board.GetComponentsInChildren<DoorOscillation>();
        foreach (var doorOscillation in doorOscillations)
        {
            doorOscillation.StartOscillation();
        }
    }

 
}
