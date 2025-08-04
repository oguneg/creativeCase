using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] InputHandler inputHandler;
    [SerializeField] private MobHandler mobPrefab, enemyPrefab;
    [SerializeField] private Transform enemyBase, playerBase;
    [SerializeField] private ParticleSystem smokeParticle;
    bool isGameComplete = false;
    private List<MobHandler> activeMobList = new List<MobHandler>();
    [SerializeField] int mobCount = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        inputHandler.Tick();

        /*for (int i = 0; i < mobCount; i++)
        {
            activeMobList[i].Tick();
        }*/

        foreach (var element in activeMobList)
        {
            element.Tick();
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
        var mob = Instantiate(isEnemy ? enemyPrefab : mobPrefab);
        mob.SetTarget(isEnemy ? playerBase.transform.position : enemyBase.transform.position);
        AddMob(mob);
        return mob;
    }

    public void PlayParticleAt(Vector3 position)
    {
        var particle = Instantiate(smokeParticle);
        particle.transform.position = position;
        particle.Play();
    }

    public void Defeat()
    {
        if (isGameComplete) return;
        isGameComplete = true;
        UIManager.instance.CompleteGame(false);
    }

    public void Win()
    {
        if (isGameComplete) return;
        isGameComplete = true;
        UIManager.instance.CompleteGame(true);
    }
}
