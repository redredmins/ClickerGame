using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1. MaxHp, curHp
    // 2. Appear(), GetHit(), Dead()

    [SerializeField] GameObject efcDamagePrefab;

    int maxHp;
    int curHp;
    public bool isDead { private set; get; }

    [SerializeField] Animator animator;


    public void Appear(int maxHp)
    { 
        this.maxHp = maxHp;
        curHp = maxHp;
        isDead = false;
    }

    public void Disappear()
    {
        Destroy(this.gameObject);
    }

    public void GetHit(int damage)
    {
        if (isDead) return;

        curHp -= damage;
        GameObject efcObj = Instantiate(efcDamagePrefab, transform);
        UIEffectText efcText = efcObj.GetComponent<UIEffectText>();
        efcText.UpdateText((damage * -1).ToString());

        if (curHp <= 0)
        {
            Dead();
        }
        else
        {
            animator.SetTrigger("GetHit");
        }
    }

    void Dead()
    {
        isDead = true;
        animator.SetTrigger("Die");

        GameManager.Manager.UpdateEnemyDie();
        
        Destroy(this.gameObject, 2f);
    }

}
