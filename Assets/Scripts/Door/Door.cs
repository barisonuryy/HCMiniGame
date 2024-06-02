using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyType requiredKeyType;
    private bool isUnlocked = false;

    public bool TryUnlock(KeyType keyType)
    {
        if (isUnlocked) return true;
        if (keyType == requiredKeyType)
        {
            isUnlocked = true;
            return true;
        }
     
        return false;
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }
}
