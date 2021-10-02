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

    private void Awake()
    {
        gameLogic = new GameLogic(soundChanel);
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
