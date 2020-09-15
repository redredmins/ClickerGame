using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected int level;
    public int Level
    {
        protected set
        {
            level = value;
            PlayerPrefs.SetInt(GetSaveLevelKey(), level);
        }
        get
        {
            return PlayerPrefs.GetInt(GetSaveLevelKey(), 1);
        }
    }

    [Header("attacker info")]
    [SerializeField] protected AttackAttribute attackAttribute;
    [SerializeField] protected int power = 3;
    public int damage
    {
        get { return power * Level; }
    }

    protected Enemy target;
    protected abstract string GetSaveLevelKey();

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

    protected virtual void Attack()
    {
        if (target == null) return;

        target.GetHit(new AttackInfo(attackAttribute, damage));
    }
}
