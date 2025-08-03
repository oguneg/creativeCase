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
    private bool canMultiply = false;
    public void Initialize(bool isMultiplied = false)
    {
        canMultiply = !isMultiplied;
        if (isMultiplied) StartCoroutine(MultiplyCooldown());
        target = transform.position + Vector3.forward * 200;
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutBounce);
    }

    public void Tick()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private IEnumerator MultiplyCooldown()
    {
        yield return new WaitForSeconds(1f);
        canMultiply = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (canMultiply && col.CompareTag("Gate"))
        {
            col.GetComponent<MultiplierGateHandler>().Multiply(this);
        }

        else if (col.CompareTag("SplineEntrance"))
        {
            col.GetComponentInParent<TubeController>().SwallowMob(this);
        }
    }
}
