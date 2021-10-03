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
    [SerializeField]
    private GameplayEventSystem gameEventChanel;

    private VulcanController vulcanController;
    private GameLogic gameLogic;

    public GameObject debugingCar;

    private void Awake()
    {
        gameLogic = new GameLogic(this);
        vulcanController = new VulcanController(fieldController.vulcanParticleSystem);

        if (debugingCar != null)
        {
            gameLogic.SetCharacterController(debugingCar.GetComponent<PlayerCharakterController>());
        }
        if (uiController != null)
        {
            uiController.SetLevelController(this);
        }
    }

	public void ResetGame()
	{
        gameLogic.ResetGameLogic();

        if (debugingCar != null)
        {
            debugingCar.transform.position = new Vector3(485, 23.34f, 288);
            debugingCar.transform.rotation = Quaternion.identity;
			var rigidCar = debugingCar.GetComponent<Rigidbody>();
			rigidCar.velocity = new Vector3(0, 0, 0);
			rigidCar.angularVelocity = new Vector3(0, 0, 0);
        }
	}

	private void FixedUpdate()
    {
        gameLogic.UpdateGameLogic();
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
}
