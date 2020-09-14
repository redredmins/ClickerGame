using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 1. 레벨, 경험치, 공격력
    // 2. 공격(), 경헙치업(), 레벨업()

    int level;
    int exp;
    int power;

    [SerializeField] private Animator animator;


    void Start()
    {
    
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            animator.SetTrigger("Attack");
        }
    }
}
