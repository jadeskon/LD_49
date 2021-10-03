using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState
{
	GameLogic owner;

    UIController uiController;
	GameplayEventSystem eventSystem;

	private bool isStateAktive = false;

	public GameOverState(UIController uiController, GameplayEventSystem eventSystem)
	{
		this.uiController = uiController;
		this.eventSystem = eventSystem;

		isStateAktive = false;

		eventSystem.gameOverEvent += EndGame;
	}

	~GameOverState()
	{
		eventSystem.gameOverEvent -= EndGame;
	}

	public void UpdateGameOverState()
	{

	}

	public void EndGame (string reason)
    {
        uiController.ActivateGameOverScreen(reason);
    }

	public bool IsStateAktive()
	{
		return isStateAktive;
	}

	public void RestState()
	{

	}
}
