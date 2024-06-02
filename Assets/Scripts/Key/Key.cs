using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyType keyType;
    [SerializeField] private GameObject redUI, blueUI;
    private void OnDestroy()
    {
        if (keyType == KeyType.Red)
        {
            redUI.gameObject.SetActive(true);
        }
        else if (keyType == KeyType.Blue)
        {
            blueUI.gameObject.SetActive(true);
        }
    }
}

