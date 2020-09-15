﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 1. 레벨, 경험치, 공격력
    // 2. 공격(), 경헙치업(), 레벨업()

    [SerializeField] Animator animator;

    [Header("player info")]
    [SerializeField] AttackAttribute attackAttribute;

    private int level;
    public int Level
    {
        private set
        {
            level = value;
            PlayerPrefs.SetInt("Level", level);
        }
        get
        {
            return level;
        }
    }
    int exp;
    [SerializeField] int power = 3;
    public int damage
    {
        get { return power * Level; }
    }

    Enemy target;


    public void Init(int level, int exp)
    {
        Level = level;
        this.exp = exp;
    }

    public void SetTarget(Enemy enemy)
    {
        target = enemy;
    }

    public void UpdateLevel(int upLevel)
    {
        Level += upLevel;
    }

    public int GetNextDamage(int addLevel)
    {
        return (Level + addLevel) * power;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (target == null) return;

        animator.SetTrigger("Attack");
        target.GetHit(new AttackInfo(attackAttribute, damage));
    }
}
