using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UnityEngine;
using DG.Tweening;
using System.Runtime.Remoting.Metadata;
using UnityEngine.Video;

public class CannonHandler : MonoBehaviour
{
    [SerializeField] private float shootInterval;
    [SerializeField] private Transform cannonVisual;
    private GameManager gameManager;
    private float lastX;
    private float lastShootTime;
    [SerializeField] private MobHandler mobPrefab;
    [SerializeField] private float moveSpeed, moveBoundX;
    [SerializeField] private Transform[] wheels;
    [SerializeField] private Transform spawnPoint;
    void Awake()
    {
        gameManager = GameManager.instance;
        lastX = transform.position.x;
    }

    public void Move(float x)
    {
        CheckShoot();
        var pos = transform.position + Vector3.right * x * Time.deltaTime * moveSpeed;
        pos.x = Mathf.Clamp(pos.x, -moveBoundX, moveBoundX);
        RollWheels(pos.x - lastX);
        lastX = pos.x;
        transform.position = pos;
    }

    private void RollWheels(float x)
    {
        for (int i = 0; i < 4; i++)
        {
            wheels[i].Rotate(Vector3.right * x * 100f, Space.Self);
        }
    }

    private void CheckShoot()
    {
        if (Time.time > lastShootTime + shootInterval) Shoot();
    }

    private void Shoot()
    {
        lastShootTime = Time.time;
        cannonVisual.DOScale(0.12f, 0.075f).SetRelative().SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
        cannonVisual.DOMoveZ(-0.45f, 0.075f).SetRelative().SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
        SpawnMob();
    }

    private void SpawnMob()
    {
        var mob = Instantiate(mobPrefab);
        mob.transform.localScale = Vector3.zero;
        mob.transform.position = spawnPoint.transform.position;
        gameManager.AddMob(mob);
        mob.Initialize();
    }
}
