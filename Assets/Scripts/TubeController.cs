using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Microsoft.SqlServer.Server;
using Dreamteck.Splines;
using UnityEngine.Video;
public class TubeController : MonoBehaviour
{
    [SerializeField] private Transform tubeExit;
    [SerializeField] private Transform spherePrefab;
    [SerializeField] private SplineComputer computer;
    [SerializeField] private float travelTime;
    public void SwallowMob(MobHandler mob)
    {
        mob.gameObject.SetActive(false);
        StartCoroutine(SpawnSphere(mob));
    }

    private void SpitMob(MobHandler mob)
    {
        mob.transform.position = tubeExit.transform.position;
        mob.gameObject.SetActive(true);
    }

    private IEnumerator SpawnSphere(MobHandler mob)
    {
        var sphere = Instantiate(spherePrefab);
        sphere.transform.localScale = Vector3.zero;
        sphere.transform.DOScale(2.3f, 0.2f).SetEase(Ease.OutBack);
        sphere.transform.position = computer.EvaluatePosition(0);
        float time = 0f;
        while (time / travelTime < 0.97f)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            sphere.transform.position = computer.EvaluatePosition(time / travelTime);

        }
        SpitMob(mob);
        Destroy(sphere.gameObject);
    }
}
