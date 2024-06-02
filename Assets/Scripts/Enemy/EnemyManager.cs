using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private List<IEnemy> enemies = new List<IEnemy>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy(IEnemy enemy)
    {
        enemies.Add(enemy);
        enemy.OnEnemyKilled += HandleEnemyKilled;
    }

    private void HandleEnemyKilled(IEnemy enemy)
    {
        
        enemies.Remove(enemy);
       
        
        if (enemies.Count == 0)
        {
            Board.Instance.RemoveBoard();
            Board.Instance.UnlockDoor() ;
        }
        else
        {
            Board.Instance.RemoveBoard();
        }
    }
}
