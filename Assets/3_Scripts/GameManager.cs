using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 1. 처치한 적의 수, 적 등장한 이후 지난 시간, 적을 처치하는데 주어진 시간
    // 2. 적 스폰(), 적이 죽었을때 시간 처리(), 총 처치한 적의 수 카운팅()

    [SerializeField] Player player;
    [SerializeField] Pet pet;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] UIManager uiManager;

    int myCoin;
    int Coin
    {
        set
        {
            myCoin = value;
            uiManager.UpdateCoin(myCoin);
            PlayerPrefs.SetInt("Coin", myCoin);
        }
        get
        {
            return myCoin;
        }
    }

    Enemy curEnemy;
    int deadEnemy;
    int DeadEnemy
    {
        set
        {
            deadEnemy = value;
            uiManager.UpdateKillCount(deadEnemy);
        }
        get
        {
            return deadEnemy;
        }
    }
    const float timeForKillEnemy = 5f;
    float curTime;

    const int levelUpPrice = 10;


    void Start()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        DeadEnemy = 0;
        curTime = 0;

        SpawnEnemy();

        uiManager.UpdatePlayerLevelUpButton(player.Level,
                                            player.damage,
                                            player.GetNextDamage(1),
                                            (player.Level * levelUpPrice));

        uiManager.UpdatePetLevelUpButton(pet.Level,
                                            pet.damage,
                                            pet.GetNextDamage(1),
                                            pet.Level * levelUpPrice);

        uiManager.UpdateEnemyLevelUpButton(Enemy.Level * levelUpPrice);
    }

    void Update()
    {
        SpendTime();
    }

    void SpendTime()
    {
        if (curEnemy == null || curEnemy.isDead == true) return;

        curTime += Time.deltaTime;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        if (curTime >= timeForKillEnemy)
        {
            curTime = 0;

            // 실패에 대한 처리
            curEnemy.Disappear();
            Invoke("SpawnEnemy", 1f);
        }
    }

    void SpawnEnemy()
    {
        curTime = 0;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject enemyObj = Instantiate(enemyPrefabs[randomIndex], spawnEnemyPos);
        curEnemy = enemyObj.GetComponent<Enemy>();
        curEnemy.Appear(10);

        player.SetTarget(curEnemy);
        pet.SetTarget(curEnemy);
    }

    public void UpdateEnemyDie(int getCoin)
    {
        DeadEnemy += 1;
        Coin += getCoin;

        Invoke("SpawnEnemy", 3f);
    }

    public void UpdatePlayerLevel(int upLevel)
    {
        if (UpdateAttackerLevel<Player>(player, upLevel))
        {
            uiManager.UpdatePlayerLevelUpButton(player.Level,
                                                player.damage,
                                                player.GetNextDamage(upLevel),
                                                player.Level * levelUpPrice);
        }
    }

    public void UpdatePetLevel(int upLevel)
    {
        if (UpdateAttackerLevel<Pet>(pet, upLevel))
        {
            uiManager.UpdatePetLevelUpButton(pet.Level,
                                            pet.damage,
                                            pet.GetNextDamage(upLevel),
                                            pet.Level * levelUpPrice);
        }
    }

    bool UpdateAttackerLevel<A>(A attacker, int upLevel)
        where A : Attacker
    {
        int price = attacker.Level * levelUpPrice;
        if (Coin >= price)
        {
            Coin -= price;
            attacker.UpdateLevel(upLevel);

            return true;
        }
        else
            return false;
    }

    public void UpdateEnemyLevel(int upLevel)
    {
        int price = Enemy.Level * levelUpPrice; // 레벨업에 필요한 돈
        if (Coin >= price)
        {
            Coin -= price;

            Enemy.Level += upLevel;
            price = Enemy.Level * levelUpPrice;
            uiManager.UpdateEnemyLevelUpButton(price);
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Remove"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
