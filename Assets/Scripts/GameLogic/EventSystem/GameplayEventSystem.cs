using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public event Action<bool> sacrifizeZoneTriggerEvent;
    public void SacrifizeZoneTrigger(bool sacrifizeZone)
    {
        if (sacrifizeZoneTriggerEvent != null)
        {
            sacrifizeZoneTriggerEvent(sacrifizeZone);
        }
    }

    public event Action<bool> saveZoneTriggerEvent;
    public void SaveZoneTrigger(bool saveZone)
    {
        if (saveZoneTriggerEvent != null)
        {
            saveZoneTriggerEvent(saveZone);
        }
    }

    public event Action<string> infoPopupTriggerEvent;
    public void InfoPopupTrigger(string textToDisplay)
    {
        if (infoPopupTriggerEvent != null)
        {
            infoPopupTriggerEvent(textToDisplay);
        }
    }

    public event Action<List<HouseController>> setPersonsTriggerEvent;
    public void SetPersonsTrigger(List<HouseController> houseControllers)
    {
        if (setPersonsTriggerEvent != null)
        {
            setPersonsTriggerEvent(houseControllers);
        }
    }
}
