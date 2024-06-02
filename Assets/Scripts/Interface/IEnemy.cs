using System;

public interface IEnemy
{
    void Die();
    event Action<IEnemy> OnEnemyKilled;
}
