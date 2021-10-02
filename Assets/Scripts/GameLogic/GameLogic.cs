using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic 
{
    private SoundEventSystem soundChanel;
    private PlayerCharakterController charController;
    private InputController inputController;

    public GameLogic(SoundEventSystem iniSoundChanel, InputController iniInputController)
    {
        inputController = iniInputController;
        soundChanel = iniSoundChanel;
    }
    public void UpdateGameLogic()
    {
        charController.UpdatePlayerController(inputController.getInput());
    }



    public void SetCharacterController(PlayerCharakterController newCharController)
    {
        charController = newCharController;
    }
}
