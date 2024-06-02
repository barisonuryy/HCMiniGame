using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Entity,IEnemy
{
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");
    public TextMeshProUGUI levelText;
    public Enemy(int level) : base(level) { }
    public GameObject destructionEffectPrefab;
    public event Action<IEnemy> OnEnemyKilled;
    private void Start()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(this);
        }
   
        UpdateLevelText();
    }

    public override void Attack(Entity target)
    {
        if (target != null)
        {
            PlayAttackAnimation();
            target.Destroy();
        }
    }
    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Lvl" + Level;
        }
    }
    public void Die()
    {
        OnEnemyKilled?.Invoke(this);
    }
    private void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(AttackTrigger);
            // Bir sonraki karede tetikleyiciyi sıfırlamak için coroutine kullanıyoruz
            StartCoroutine(ResetTrigger(AttackTrigger));
        }
    }

    private IEnumerator ResetTrigger(int triggerHash)
    {
        yield return null; // Bir kare bekleyelim
        animator.ResetTrigger(triggerHash);
    }

    public override void Destroy()
    {
        Debug.Log("Enemy is destroyed");
        if (destructionEffectPrefab != null)
        {
            Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity);
        }

        // GameObject'i yok et
        Destroy(gameObject,0.5f);
    }

    private void OnDestroy()
    {
        levelText.transform.parent.gameObject.SetActive(false);
    }

}
