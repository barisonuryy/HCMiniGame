using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public bool allDie;
    public List<GameObject> boards;
    [SerializeField] private GameObject levelCompleteText;

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

    public void RemoveBoard()
    {
        if (boards.Count > 0)
        {
            GameObject board = boards[0];
            boards.RemoveAt(0);
            Destroy(board);
            Debug.Log("Board removed from the door.");
        }
    }

   public void UnlockDoor()
    {
        allDie = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(allDie)
        levelCompleteText.SetActive(true);
    }
}
