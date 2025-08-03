using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TubeController : MonoBehaviour
{
    [SerializeField] private Transform tubeExit;
    public void SwallowMob(MobHandler mob)
    {
        mob.gameObject.SetActive(false);
        DOVirtual.DelayedCall(Random.Range(1.5f,1.6f), () => SpitMob(mob));
    }

    private void SpitMob(MobHandler mob)
    {
        mob.transform.position = tubeExit.transform.position;
        mob.gameObject.SetActive(true);
    } 
}
