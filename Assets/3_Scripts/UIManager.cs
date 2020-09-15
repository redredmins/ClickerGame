using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text txtKillCount;
    [SerializeField] Image guageTime;
    [SerializeField] Text txtCoin;


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

}
