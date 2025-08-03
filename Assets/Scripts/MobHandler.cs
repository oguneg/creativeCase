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
    const float speed = 6f;
    private bool canMultiply = false;
    [SerializeField] private Rigidbody rb;
    public void Initialize(bool isMultiplied = false)
    {
        canMultiply = !isMultiplied;
        if (isMultiplied) StartCoroutine(MultiplyCooldown());
        //target = transform.position + Vector3.forward * 200;
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutBounce);
    }

    public void SetTarget(Vector3 pos)
    {
        target = pos;
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
        if (!isPlayer)
        {
            if (col.CompareTag("PlayerLine"))
            {
                GameManager.instance.Defeat();
            }
        }
        else
        if (canMultiply && col.CompareTag("Gate"))
        {
            col.GetComponent<MultiplierGateHandler>().Multiply(this);
        }

        else if (col.CompareTag("SplineEntrance"))
        {
            col.GetComponentInParent<TubeController>().SwallowMob(this);
        }
        else if (col.CompareTag("EnemyBase"))
        {
            col.GetComponentInParent<EnemyBaseHandler>().Damage();
            Die();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isPlayer && other.gameObject.CompareTag("Enemy"))
        {
            other.collider.GetComponent<MobHandler>().Die();
            Die();
        }
    }

    public void Die()
    {
        GameManager.instance.KillMob(this);
        Destroy(gameObject);
    }
}
