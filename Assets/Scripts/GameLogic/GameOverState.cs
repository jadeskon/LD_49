using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState
{
    UIController uiController;
	GameplayEventSystem eventSystem;

	public GameOverState(UIController uiController, GameplayEventSystem eventSystem)
	{
		this.uiController = uiController;
		this.eventSystem = eventSystem;
		eventSystem.gameOverEvent += EndGame;
	}

	~GameOverState()
	{
		eventSystem.gameOverEvent -= EndGame;
	}

	public void EndGame (string reason)
    {
        uiController.ActivateGameOverScreen(reason);
    }
}
