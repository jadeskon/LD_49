using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic 
{
    private SoundEventSystem soundChanel;
    private PlayerCharakterController charController;
    private InputController inputController;
    private UIController uiController;
    private PlayState playState;
	private GameplayEventSystem eventSystem;
	private GameOverState gameOverState;

    public int secPerBody = 10;
    public int scorePerBody = 5;

    private DateTime m_lastActionTime = DateTime.Now;

    private int score = 0;
    private float time = 180f;
    private int bodyCount = 0;
    private enum GameState
    {
        run,
        pause,
        end
    }

    public GameLogic(SoundEventSystem iniSoundChanel, InputController iniInputController, UIController iniUiController, GameplayEventSystem eventSystem)
    {
        inputController = iniInputController;
        soundChanel = iniSoundChanel;
        uiController = iniUiController;

        playState = new PlayState(this);
        this.eventSystem = eventSystem;
        gameOverState = new GameOverState(iniUiController, eventSystem);
    }

	public void UpdateGameLogic()
    {
        Inputs input = inputController.getInput();
        charController.UpdatePlayerController(input);
        if (true) //(m_lastActionTime < DateTime.Now.AddSeconds(-1))
        {
            m_lastActionTime = DateTime.Now;
            CheckActions(input);
        }
        UpdateUi();
        time -= 1 * Time.deltaTime;
        if(time <= 0f)
        {
            eventSystem.GameOver("The volcano erupts, covering the complete island with hot lava.");
        }
    }

    public void CheckActions (Inputs input)
    {
        if (input.collect)
        {
            //Collider Abfrage:
            CollectHuman();
            //SaveHuman();
            //SacrificeHuman();
        }
        if (input.menu)
        {
            CallMenu();
        }
    }

    public void SetCharacterController(PlayerCharakterController newCharController)
    {
        charController = newCharController;
    }

    public void CollectHuman ()
    {
        bodyCount++;
    }

    public void SaveHuman ()
    {
        if(bodyCount > 0)
        {
            bodyCount--;
            score += scorePerBody;
        }
    }

    public void SacrificeHuman ()
    {
        if(bodyCount > 0)
        {
            bodyCount--;
            time += secPerBody;
        }
    }

    public void CallMenu ()
    {
        uiController.SwitchPause();
    }

    public void UpdateUi ()
    {
        uiController.SetPassengersDisplay(bodyCount);
        uiController.SetScoreDisplay(score);
        uiController.SetTimerDisplay(time);
    }

    public void SpawnRandomNpc (int count)
    {
        for(int i = 0; i < count; i++)
        {
            //Spawn NPC at random House
        }
    }

}
