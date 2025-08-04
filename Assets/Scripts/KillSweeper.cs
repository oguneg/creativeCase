using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KillSweeper : MonoBehaviour
{
    bool isActive = false;
    // Update is called once per frame
    void Update()
    {
        if (isActive) return;
        if (Input.GetKeyDown(KeyCode.X))
        {
            Activate();
        }
    }

    private void Activate()
    {
        isActive = true;
        transform.DOMoveZ(100, 15).SetEase(Ease.Linear);
    }
}
