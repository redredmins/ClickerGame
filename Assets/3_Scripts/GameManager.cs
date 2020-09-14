using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. 처치한 적의 수, 적 등장한 이후 지난 시간, 적을 처치하는데 주어진 시간
    // 2. 적 스폰(), 적이 죽었을때 시간 처리(), 총 처치한 적의 수 카운팅()

    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            if (manager == null)
            {
                manager = FindObjectOfType<GameManager>();
            }
            return manager;
        }
    }

    [SerializeField] Player player;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] UIManager uiManager;

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


    void Start()
    {
        DeadEnemy = 0;
        curTime = 0;

        player.Init(PlayerPrefs.GetInt("Level", 1), PlayerPrefs.GetInt("EXP", 0));
        SpawnEnemy();
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

        GameObject enemyObj = Instantiate(enemyPrefab, spawnEnemyPos);
        curEnemy = enemyObj.GetComponent<Enemy>();
        curEnemy.Appear(10);

        player.SetTarget(curEnemy);
    }

    public void UpdateEnemyDie()
    {
        DeadEnemy += 1;

        Invoke("SpawnEnemy", 3f);
    }


}
