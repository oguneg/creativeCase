using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UnityEngine;
using DG.Tweening;

public class CannonHandler : MonoBehaviour
{
    [SerializeField] private float shootInterval;
    private float lastShootTime;
    [SerializeField] private MobHandler mobPrefab;
    [SerializeField] private float moveSpeed, moveBoundX;
    public void Move(float x)
    {
        CheckShoot();
        var pos = transform.position + Vector3.right * x * Time.deltaTime * moveSpeed;
        pos.x = Mathf.Clamp(pos.x, -moveBoundX, moveBoundX);
        transform.position = pos;
    }

    private void CheckShoot()
    {
        if (Time.time > lastShootTime + shootInterval) Shoot();
    }

    private void Shoot()
    {
        lastShootTime = Time.time;
        transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
        //Debug.Log("bam");
    }
}
