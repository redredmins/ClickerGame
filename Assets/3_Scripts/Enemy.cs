using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1. MaxHp, curHp
    // 2. Appear(), GetHit(), Dead()

    int maxHp;
    int curHp;

    [SerializeField] Animator animator;


    public void Appear(int maxHp)
    {
        animator.SetBool("IsLive", true);
        
        this.maxHp = maxHp;
        curHp = maxHp;
    }

    public void GetHit(int damage)
    {
        animator.SetTrigger("GetHit");

        curHp -= damage;
        if (curHp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        animator.SetBool("IsLive", false);
    }

}
