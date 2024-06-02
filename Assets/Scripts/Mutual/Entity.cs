using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private float attackRange;

    protected Animator animator;

    public int Level
    {
        get { return level; }
        protected set { level = value; }
    }


    public Entity(int level)
    {
        this.level = level;
    }

    public abstract void Attack(Entity target);

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public abstract void Destroy();
}
