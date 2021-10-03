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
    private GameObject playerCarInstance;
    private HumanResources hr;

    private bool isStateAktive = false;
    private bool isCarInSaveZone = false;
    private bool isCarInSacrifizeZone = false;

    public int secPerBody = 10;
    public int scorePerBody = 5;

    private int score = 0;
    private float countDownTime = 180f;

    public PlayState(GameLogic iniGameLogic)
    {
        owner = iniGameLogic;

        soundChanel = owner.GetSoundChanel();
        gameEventChanel = owner.GetGameEventChanel();
        inputController = owner.GetInputController();
        uiController = owner.GetUIController();
        vulcanController = owner.GetVulcanController();

        gameEventChanel.saveZoneTriggerEvent += SaveZoneTrigger;
        gameEventChanel.sacrifizeZoneTriggerEvent+= SacrificeZoneTrigger;

        hr = new HumanResources(this);

        SetUpGame();
    }

    public void UpdatePlaystate()
    {
        hr.UpdateHR();

        if (charController != null)
        {
            charController.UpdatePlayerController(inputController.GetInput());
        }

        if (inputController.GetInput().collect && isCarInSaveZone)
        {
            SaveHuman();
        }
        if (inputController.GetInput().collect && isCarInSacrifizeZone)
        {
            SacrificeHuman();
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        countDownTime -= Time.fixedDeltaTime;
    }

    private void SetUpGame()
    {
        isStateAktive = true;

        SetUpPlayerController();

        owner.SetCameraTargte(playerCarInstance);

        hr.SpawnPersons(20);
    }

    private void SetUpPlayerController()
    {
        playerCarInstance = MonoBehaviour.Instantiate(  owner.GetPlayerCarPrefab(),
                                                        owner.GetPlayerSpawnPos().position,
                                                        Quaternion.identity);

        charController = playerCarInstance.GetComponent<PlayerCharakterController>();
    }

	internal void ResetState()
	{
        hr.Reset();
	}

    public void SaveHuman()
    {
        if (hr.GetCountOfCarPersons() > 0)
        {
            hr.RemovePersonsOfCar();
            score += scorePerBody;
        }
    }

    public void SacrificeHuman()
    {
        if (hr.GetCountOfCarPersons() > 0)
        {
            hr.RemovePersonsOfCar();
            countDownTime += secPerBody;
        }
    }

    private void SaveZoneTrigger(bool triggerState)
    {
        isCarInSaveZone = triggerState;
    }
    private void SacrificeZoneTrigger(bool triggerState)
    {
        isCarInSacrifizeZone = triggerState;
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
        return hr.GetCountOfCarPersons();
    }

    public bool IsStateAktive()
    {
        return isStateAktive;
    }

    public GameplayEventSystem GetGameEventChanel()
    {
        return owner.GetGameEventChanel();
    }

    //Setters
    public void SetCharacterController(PlayerCharakterController newCharController)
    {
        charController = newCharController;
    }
}
