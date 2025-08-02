using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Video;
public class MultiplierGateHandler : MonoBehaviour
{
    [SerializeField] private int multiplier;
    [SerializeField] private bool isMoving;
    [SerializeField] private float minX, maxX, moveSpeed;
    [SerializeField] private TextMeshProUGUI multiplierText;

    void Start()
    {
        multiplierText.text = $"x{multiplier}";
        if (isMoving)
        {
            transform.DOMoveX(maxX, moveSpeed).SetSpeedBased().SetEase(Ease.InOutSine)
            .OnComplete(()=>
            {
                transform.DOMoveX(minX, moveSpeed).SetSpeedBased().SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            });
        }
    }

    public void Multiply(MobHandler mob)
    {
        for (int i = 0; i < multiplier-1; i++)
        {
            var newMob = GameManager.instance.SpawnMob();
            newMob.transform.position = mob.transform.position + new Vector3(Random.Range(-0.1f,0.1f),0,Random.Range(-0.1f,0.1f));
            newMob.Initialize(true);
        }
    }
}
