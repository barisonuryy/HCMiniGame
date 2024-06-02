using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKey
{
    string KeyType { get; }
}
public class BlueKey : MonoBehaviour, IKey
{
    public string KeyType => "Blue";
}

public class RedKey : MonoBehaviour, IKey
{
    public string KeyType => "Red";
    
}