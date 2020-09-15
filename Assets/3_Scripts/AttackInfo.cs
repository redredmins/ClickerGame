using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackAttribute
{
    None,
    Water,
    Fire,
    Wind,
}

// struct : 값 타입, 상속 못함, 매개변수가 없는 생성자를 만들 수 없음.
public struct AttackInfo
{
    public AttackAttribute attribute;
    int damage;

    public AttackInfo(AttackAttribute attribute, int damage)
    {
        this.attribute = attribute;
        this.damage = damage;
    }

    public int GetDamage(AttackAttribute attackedAttribute)
    {
        int addAttack = GetAddAttack(attribute, attackedAttribute);
        if (addAttack == 1) damage *= 2;
        else if (addAttack == -1) damage = Mathf.FloorToInt((float)damage * 0.5f);

        return damage;
    }

    // -1 : 데미지 감소 | 0 : 데미지 그대로 | 1 : 추가 데미지
    int GetAddAttack(AttackAttribute my, AttackAttribute your)
    {
        switch(my)
        {
            case AttackAttribute.Fire:
                if (your == AttackAttribute.Wind) return 1;
                if (your == AttackAttribute.Water) return -1;
                return 0;

            case AttackAttribute.Water:
                if (your == AttackAttribute.Fire) return 1;
                if (your == AttackAttribute.Wind) return -1;
                return 0;

            case AttackAttribute.Wind:
                if (your == AttackAttribute.Water) return 1;
                if (your == AttackAttribute.Fire) return -1;
                return 0;

            default:
                return 0;
        }
    }

}
