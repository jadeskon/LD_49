using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState
{
    UIController uiController;
	public static GameOverState Instance;

	public GameOverState(UIController uiController)
	{
		this.uiController = uiController;
		Instance = this;
	}

	public void EndGame ()
    {
        uiController.ActivateGameOverScreen();
    }

	public void OnTimeRunOut()
	{
		EndGame();
	}
}
