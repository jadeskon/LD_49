using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private CameraController camController;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private SoundEventSystem soundChanel;
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private FieldController fieldController;
    private GameLogic gameLogic;
    [SerializeField]
    private GameplayEventSystem eventSystem;

    public GameObject debugingCar;

    private void Awake()
    {
        gameLogic = new GameLogic(soundChanel, inputController, uiController, eventSystem);

        if (debugingCar != null)
        {
            gameLogic.SetCharacterController(debugingCar.GetComponent<PlayerCharakterController>());
        }
    }

    private void FixedUpdate()
    {
        gameLogic.UpdateGameLogic();
    }

    void Update()
    {
        //UpdateInputSystem
    }
}
