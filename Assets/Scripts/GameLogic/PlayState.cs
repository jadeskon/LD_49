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
    }

    public int GetScore()
    {
        return 0;
    }
}
