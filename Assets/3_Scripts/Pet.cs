using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Attacker
{
    

    protected override string GetSaveLevelKey()
    {
        return "Pet Level";
    }

    void Start()
    {
        StartCoroutine(IEAutoAttack());
    }

    IEnumerator IEAutoAttack()
    {
        while (true)
        {
            animator.SetBool("IsDash", false);

            yield return new WaitForSeconds(0.5f);

            Attack();

            float dashTime = 0f;
            Vector3 originPos = transform.position;
            Vector3 dashPos = originPos - new Vector3(2f, 0f, 0f);
            float speed = 4f;
            bool isGo = true;
            while(dashTime < 0.5f)
            {
                dashTime += Time.deltaTime;

                if (isGo == true)
                {
                    Vector3 dir = (dashPos - originPos).normalized;
                    transform.localPosition += dir * speed * (Time.deltaTime * 2);
                }
                else
                {
                    Vector3 dir = (originPos - dashPos).normalized;
                    transform.localPosition += dir * speed * (Time.deltaTime * 2);
                }
                
                yield return null;

                if (Vector3.Distance(transform.position, dashPos) < 0.1f) isGo = false;
            }

            transform.localPosition = originPos;
        }
    }

    protected override void Attack()
    {
        base.Attack();

        animator.SetBool("IsDash", true);
    }


}
