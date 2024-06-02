using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : Entity
{
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    public Character(int level) : base(level) { }
    public GameObject destructionEffectPrefab;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        UpdateLevelText();
    }
    
    public void AddExperience(int amount)
    {
        Level += amount;
        UpdateLevelText();
    }
    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Lvl" + Level;
        }
    }
    public override void Attack(Entity target)
    {
        if (target != null)
        {
            PlayAttackAnimation();
            ShowAttackUI(target);
            Debug.Log("Character attacks and destroys the enemy!");
            target.Destroy();
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        yield return null; 
        animator.ResetTrigger(triggerHash);
    }

    public override void Destroy()
    {
        Debug.Log("Character is destroyed");
        if (destructionEffectPrefab != null)
        {
            Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity);
        }

        // GameObject'i yok et
        Destroy(gameObject,1f);
    }
    private void ShowAttackUI(Entity target)
    {
        GameObject uiCanvas = target.transform.Find("Canvas").gameObject;
        GameObject attackImage = uiCanvas.transform.Find("AttackImage").gameObject;
        attackImage.SetActive(true);
    }

 
}
