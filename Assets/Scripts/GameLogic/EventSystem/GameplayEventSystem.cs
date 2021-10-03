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

    public event Action gameOverEvent;
    public void GameOver()
    {
        if (gameOverEvent != null)
        {
            gameOverEvent();
        }
    }
}
