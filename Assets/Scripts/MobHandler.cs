using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Video;
public class MobHandler : MonoBehaviour
{
    public bool isPlayer;
    private Vector3 target;
    const float speed = 5f; 
    public void Initialize()
    {
        target = transform.position + Vector3.forward * 200;
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutBounce);
    }

    public void Tick()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
