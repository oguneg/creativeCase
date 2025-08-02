using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] InputHandler inputHandler;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        inputHandler.Tick();
    }
}
