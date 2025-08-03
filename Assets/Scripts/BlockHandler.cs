using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class BlockHandler : MonoBehaviour
{
    bool isAlive = true;
    [SerializeField] private int health;
    [SerializeField] private TextMeshProUGUI healthText;
    public void Damage()
    {
        if (!isAlive) return;
        health--;
        transform.DOScale(0.05f, 0.075f).SetLoops(2,LoopType.Yoyo).SetRelative().SetEase(Ease.InOutBack);
        if (health == 0)
        {
            isAlive = false;
            DestroyBlock();
        }
        healthText.text = $"{health}";
    }

    private void DestroyBlock()
    {
        transform.DOScale(0, 0.2f).SetEase(Ease.InBack);
    }
}
