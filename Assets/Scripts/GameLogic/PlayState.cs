using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState
{
    private GameLogic owner;

    private SoundEventSystem soundChanel;
    private InputController inputController;
    private UIController uiController;
    private VulcanController vulcanController;
    private GameplayEventSystem gameEventChanel;

    private PlayerCharakterController charController;    
    private HumanResources hr;

    private bool isStateAktive = false;

    public int secPerBody = 10;
    public int scorePerBody = 5;

    private int score = 0;
    private float countDownTime = 180f;
    private int pasangers = 0;

    public PlayState(GameLogic iniGameLogic)
    {
        owner = iniGameLogic;

        soundChanel = owner.GetSoundChanel();
        gameEventChanel = owner.GetGameEventChanel();
        inputController = owner.GetInputController();
        uiController = owner.GetUIController();
        vulcanController = owner.GetVulcanController();

        hr = new HumanResources(owner.GetGameEventChanel());

        SetUpGame();
    }


    public void UpdatePlaystate()
    {
        charController.UpdatePlayerController(inputController.GetInput());
    }

    private void SetUpGame()
    {
        isStateAktive = true;

        hr.SpawnPersons(5);
    }

	internal void ResetState()
	{
        hr.Reset();
	}

    public void SaveHuman()
    {
        if (pasangers > 0)
        {
            pasangers--;
            score += scorePerBody;
        }
    }

    public void SacrificeHuman()
    {
        if (pasangers > 0)
        {
            pasangers--;
            countDownTime += secPerBody;
        }
    }

    //Getters
    public float GetCountDownTime()
    {
        return countDownTime;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetAmountOfPasangers()
    {
        return pasangers;
    }

    public bool IsStateAktive()
    {
        return isStateAktive;
    }

    //Setters
    public void SetCharacterController(PlayerCharakterController newCharController)
    {
        charController = newCharController;
    }
}
