using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic 
{
    private LevelController owner;

    private SoundEventSystem soundChanel;
    private InputController inputController;
    private UIController uiController;
    private VulcanController vulcanController;
	private GameplayEventSystem gameEventChanel;

    private PlayState playState;
	private GameOverState gameOverState;



    public GameLogic(LevelController levelController)
    {
        owner = levelController;

        soundChanel = owner.GetSoundChanel();
        gameEventChanel = owner.GetGameEventChanel();
        inputController = owner.GetInputController();
        uiController = owner.GetUIController();
        vulcanController = owner.GetVulcanController();

        playState = new PlayState(this);
        gameOverState = new GameOverState(uiController, gameEventChanel);
    }

	internal void ResetGameLogic()
	{
        playState.ResetState();
	}

	public void UpdateGameLogic()
    {
        if (playState.IsStateAktive())
        {
            playState.UpdatePlaystate();
        }
        else
        {
            gameOverState.UpdateGameOverState();
        }

        UpdateUi();
    }

    public void SetCharacterController(PlayerCharakterController newCharController)
    {
        playState.SetCharacterController(newCharController);
    }
          

    public void CallMenu ()
    {
        uiController.SwitchPause();
    }

    public void UpdateUi ()
    {
        uiController.SetPassengersDisplay(playState.GetAmountOfPasangers());
        uiController.SetScoreDisplay(playState.GetScore());
        uiController.SetTimerDisplay(playState.GetCountDownTime());
    }

    //Getters
    public SoundEventSystem GetSoundChanel()
    {
        return soundChanel;
    }
    public GameplayEventSystem GetGameEventChanel()
    {
        return gameEventChanel;
    }
    public InputController GetInputController()
    {
        return inputController;
    }
    public UIController GetUIController()
    {
        return uiController;
    }
    public VulcanController GetVulcanController()
    {
        return vulcanController;
    }
    

}
