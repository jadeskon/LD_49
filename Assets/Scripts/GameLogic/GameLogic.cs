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
        uiController.SetHR(playState.GetHR());
        gameOverState = new GameOverState(uiController, gameEventChanel);

		inputController.OnMenu += InputController_OnMenu;
    }

	public void ResetGameLogic()
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

	private void InputController_OnMenu()
	{
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        LevelController.MuteSoundVolume = !LevelController.MuteSoundVolume;
        uiController.SwitchPause();
	}

    public void UpdateUi ()
    {
        uiController.SetPassengersDisplay((int)playState.GetAmountOfPasangers());
        uiController.SetSavedPeople(playState.savedPeople);
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

    public GameObject GetPlayerCarPrefab()
    {
        return owner.GetPlayerCarPrefab();
    }

    public Transform GetPlayerSpawnPos()
    {
        return owner.GetPlayerSpawnPos();
    }

    //Setters
    public void SetCameraTargte(Transform newTarget)
    {
        owner.SetCameraTarget(newTarget);
    }

}
