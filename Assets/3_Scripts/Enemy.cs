using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1. MaxHp, curHp
    // 2. Appear(), GetHit(), Dead()

    [SerializeField] GameObject efcDamagePrefab;
    [SerializeField] GameObject efcCoinPrefab;
    [SerializeField] Animator animator;

    [Header("enemy info")]
    [SerializeField] AttackAttribute attackAttribute;
    [SerializeField] int baseCoin;
    static int level;
    public static int Level
    {
        set
        {
            level = value;
            PlayerPrefs.SetInt("Enemy Level", level);
            Debug.Log("level : " + level);
        }
        get
        {
            return PlayerPrefs.GetInt("Enemy Level", 1);
        }
    }
    public int Coin
    {
        get { return baseCoin * Level; }
    }

    int maxHp;
    int curHp;
    public bool isDead { private set; get; }


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

    public void GetHit(AttackInfo attackInfo)
    {
        if (isDead) return;

        int damage = attackInfo.GetDamage(attackAttribute);
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
        Instantiate(efcCoinPrefab, transform);

        GameManager.Manager.UpdateEnemyDie(Coin);
        
        Destroy(this.gameObject, 2f);
    }

}
