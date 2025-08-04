using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI statusText;

    public void CompleteGame(bool isSuccess)
    {
        statusText.text = isSuccess ? "YOU WON" : "DEFEAT :(";
        statusText.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce);
        if (isSuccess)
        {
            AudioManager.instance.PlayWon();
        }
        else
        {
            AudioManager.instance.PlayLoss();
        }
    }
}
