using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Attacker
{
    

    protected override string GetSaveLevelKey()
    {
        return "Pet Level";
    }

    IEnumerator IEAutoAttack()
    {
        
    }


}
