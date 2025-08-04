using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBaseHandler : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnBatchSize;
    [SerializeField] private int health;
    [SerializeField] private TextMeshProUGUI healthText;
    private bool isAlive = true;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        healthText.text = $"{health}";
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
            mob.transform.position = transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(-1f, 1f));
            mob.transform.rotation = transform.rotation;
            mob.Initialize();
        }
    }

    public void Damage()
    {
        if (!isAlive) return;
        health--;
        if (health == 0)
        {
            isAlive = false;
            GameManager.instance.Win();
        }
        healthText.text = $"{health}";
    }
}
