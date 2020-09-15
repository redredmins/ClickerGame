using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text txtKillCount;
    [SerializeField] Image guageTime;
    [SerializeField] Text txtCoin;

    [Header("Level Up Buttons")]
    [SerializeField] Text txtPlayerLevelInfo;
    [SerializeField] Text txtPlayerLevelUpPrice;
    [SerializeField] Text txtEnemyLevelInfo;
    [SerializeField] Text txtEnemyLevelUpPrice;
    [SerializeField] Text txtPetLevelInfo;
    [SerializeField] Text txtPetLevelUpPrice;


    public void UpdateKillCount(int killCount)
    {
        txtKillCount.text = killCount.ToString();
    }

    public void UpdateTime(float maxTime, float spendTime)
    {
        float leftTime = (maxTime - spendTime) / maxTime ; // full로 남아있으면 1
        guageTime.fillAmount = leftTime;
    }

    public void UpdateCoin(int coin)
    {
        txtCoin.text = coin.ToString();
    }

    public void UpdatePlayerLevelUpButton(int curLevel, int curDamage, int nextDamage, int price)
    {
        txtPlayerLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);
        txtPlayerLevelUpPrice.text = price.ToString();
    }

    public void UpdatePetLevelUpButton(int curLevel, int curDamage, int nextDamage, int price)
    {
        txtPetLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);
        txtPetLevelUpPrice.text = price.ToString();
    }

    string GetAttackerLevelInfo(int curLevel, int curDamage, int nextDamage)
    {
        return string.Format("Lv. {0} > <b>{1}</b>\n<size=40>(dam : {2} > {3})</size>",
                        curLevel, (curLevel + 1), curDamage, nextDamage);
    }

    public void UpdateEnemyLevelUpButton(int price)
    {
        //Enemy.Level
        string info = string.Format("Lv. {0} > <b>{1}</b>\n<size=40>({2}배 추가 획득)</size>",
                        Enemy.Level, (Enemy.Level + 1), Enemy.Level);
        
        txtEnemyLevelInfo.text = info;

        txtEnemyLevelUpPrice.text = price.ToString();
    }

}
