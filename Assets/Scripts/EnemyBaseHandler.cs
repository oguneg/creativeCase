using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseHandler : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnBatchSize;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var wfs = new WaitForSeconds(spawnInterval);
        while (true)
        {
            yield return wfs;
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnBatchSize; i++)
        {
        var mob = GameManager.instance.SpawnMob(true);
        mob.transform.position = transform.position + new Vector3(Random.Range(-1,1),0,Random.Range(-1,1));
        mob.transform.rotation = transform.rotation;
        mob.Initialize();
        }
    }
}
