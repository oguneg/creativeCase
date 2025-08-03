using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] InputHandler inputHandler;
    [SerializeField] private MobHandler mobPrefab,enemyPrefab;
    [SerializeField] private Transform enemyBase, playerBase;

    private List<MobHandler> activeMobList = new List<MobHandler>();
    int mobCount = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        inputHandler.Tick();
        for (int i = 0; i < mobCount; i++)
        {
            activeMobList[i].Tick();
        }
    }

    public void AddMob(MobHandler mob)
    {
        activeMobList.Add(mob);
        mobCount++;
    }

    public void KillMob(MobHandler mob)
    {
        activeMobList.Remove(mob);
        mobCount--;
    }

    public MobHandler SpawnMob(bool isEnemy = false)
    {
        //if (mobCount > 1000) return null;
        var mob = Instantiate(isEnemy ? enemyPrefab: mobPrefab);
        mob.SetTarget(isEnemy ? playerBase.transform.position : enemyBase.transform.position);
        AddMob(mob);
        return mob;
    }
}
