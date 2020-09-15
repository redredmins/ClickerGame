using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Attacker
{
    // 1. 레벨, 경험치, 공격력
    // 2. 공격(), 경헙치업(), 레벨업()

    protected override string GetSaveLevelKey()
    {
        return "Player Level";
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        base.Attack();

        animator.SetTrigger("Attack");
    }
}
