using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/GamePlayEvents")]
public class GameplayEventSystem : ScriptableObject
{
    public event Action<HouseController> personCollectedEvent;
    public void PersonCollected(HouseController homeOfPerson)
    {
        if (personCollectedEvent != null)
        {
            personCollectedEvent(homeOfPerson);
        }
    }

    public event Action<HouseController> registerHomeEvent;
    public void RegisterHome(HouseController homeToRegister)
    {
        if (registerHomeEvent != null)
        {
            registerHomeEvent(homeToRegister);
        }
    }
    public event Action<string> gameOverEvent;
    public void GameOver(string death)
    {
        if (gameOverEvent != null)
        {
            gameOverEvent(death);
        }
    }
}
