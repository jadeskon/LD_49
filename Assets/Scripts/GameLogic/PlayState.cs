using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState
{
    private HumanResources hr;
    GameplayEventSystem eventSystem;

    public PlayState(GameLogic iniGameLogic, GameplayEventSystem eventSystem)
    {
        hr = new HumanResources(eventSystem);
        this.eventSystem = eventSystem;

        hr.SpawnPersons(5);
    }

    public void Update()
    {
        
    }

    public int GetScore()
    {
        return 0;
    }

	internal void Reset()
	{
        hr.Reset();
	}
}
