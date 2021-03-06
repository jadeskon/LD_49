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

    public int secPerBody = 30;
    public int scorePerBody = 50;

    private int score = 0;
    private const float START_COUNT_DOWN_TIME = 300f;
    private float countDownTime = START_COUNT_DOWN_TIME;
    float saveCooldownTime = 0;
    float timeBetweenSaves = 0.8f;
    float sacriviceCooldownTime = 0;
    float timeBetweensacrivice = 0.8f;
	public int savedPeople;

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
        gameEventChanel.personCollectedEvent += PickUpPerson;

        hr = new HumanResources(this);

        SetUpGame();
    }

    public HumanResources GetHR()
    {
        return hr;
    }

    public void UpdatePlaystate()
    {
        hr.UpdateHR();

        if (charController != null)
        {
            charController.UpdatePlayerController(inputController.GetInput());
        }

        saveCooldownTime += Time.fixedDeltaTime;
        sacriviceCooldownTime += Time.fixedDeltaTime;

        if (inputController.GetInput().collect && isCarInSaveZone && saveCooldownTime > timeBetweenSaves)
        {
            saveCooldownTime = 0f;
            SaveHuman();
        }
        if (inputController.GetInput().collect && isCarInSacrifizeZone && sacriviceCooldownTime > timeBetweensacrivice)
        {
            sacriviceCooldownTime = 0f;
            SacrificeHuman();
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        countDownTime -= Time.fixedDeltaTime;

        if (countDownTime < 0)
        {
            isStateAktive = false;
            gameEventChanel.GameOver("The volcano erupted - at least you can watch the Fireworks!");
        }
    }

    private void SetUpGame()
    {
        isStateAktive = true;

        SetUpPlayerController();

        owner.SetCameraTargte(charController.GetCameraTarget());

        hr.SpawnPersons(20);
    }

    private void SetUpPlayerController()
    {
        if(playerCarInstance != null)
			UnityEngine.Object.Destroy(playerCarInstance);
		playerCarInstance = MonoBehaviour.Instantiate(  owner.GetPlayerCarPrefab(),
                                                        owner.GetPlayerSpawnPos().position,
                                                        Quaternion.identity);

        charController = playerCarInstance.GetComponent<PlayerCharakterController>();
    }

	public void ResetState()
	{
        isCarInSaveZone = false;
        isCarInSacrifizeZone = false;

        score = 0;
        countDownTime = START_COUNT_DOWN_TIME;
        savedPeople = 0;

        hr.Reset();

        SetUpGame();
    }

    public void SaveHuman()
    {
        if (hr.GetCountOfCarPersons() > 0)
        {
            hr.RemovePersonOfCar();
            charController.SetPasengersDisplay(hr.GetCountOfCarPersons());
            score += scorePerBody;
            ++savedPeople;
        }
    }

    public void SacrificeHuman()
    {
        if (hr.GetCountOfCarPersons() > 0)
        {
            hr.RemovePersonOfCar();
            charController.SetPasengersDisplay(hr.GetCountOfCarPersons());
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

    private void PickUpPerson(HouseController houseController)
    {
        hr.PickUpPerson(houseController);
        charController.SetPasengersDisplay(hr.GetCountOfCarPersons());
        //Play Sound for Picking someone Up
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

    public uint GetAmountOfPasangers()
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
