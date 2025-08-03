using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Microsoft.SqlServer.Server;
using Dreamteck.Splines;
using UnityEngine.Video;
public class TubeController : MonoBehaviour
{
    [SerializeField] private Transform tubeExit,tubeEnter;
    [SerializeField] private Transform spherePrefab;
    [SerializeField] private SplineComputer computer;
    [SerializeField] private float travelTime;
    private Vector3 exitPos;
    void Awake()
    {
        exitPos = tubeExit.transform.position;
        exitPos.y = 0;
    }

    public void SwallowMob(MobHandler mob)
    {
        mob.gameObject.SetActive(false);

        tubeEnter.DOKill();
        tubeEnter.localScale = Vector3.one * 0.8f;
        tubeEnter.DOScale(0.9f, 0.075f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBack);

        StartCoroutine(SpawnSphere(mob));
    }

    private void SpitMob(MobHandler mob)
    {
        mob.transform.position = exitPos;
        mob.gameObject.SetActive(true);
    }

    private IEnumerator SpawnSphere(MobHandler mob)
    {
        var sphere = Instantiate(spherePrefab);
        sphere.transform.localScale = Vector3.zero;
        sphere.transform.DOScale(2.3f, 0.2f).SetEase(Ease.OutBack);
        sphere.transform.position = computer.EvaluatePosition(0);
        float time = 0f;
        while (time / travelTime < 1f)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            sphere.transform.position = computer.EvaluatePosition(Mathf.Min(1f, time / travelTime));

        }
        SpitMob(mob);
        Destroy(sphere.gameObject);
    }
}
