using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static bool MuteSoundVolume = false;

    [Header("Chanels")]
    [SerializeField]
    private SoundEventSystem soundChanel;
    [SerializeField]
    private GameplayEventSystem gameEventChanel;

    [Header("Controller")]    
    [SerializeField]
    private UIController uiController;    
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private FieldController fieldController;
    [SerializeField]
    private CameraController camController;

    [Header("GamePlay")]
    [SerializeField]
    private GameObject playerCarPrefab;

    private VulcanController vulcanController;
    private GameLogic gameLogic;

    [Header("Debugging")]
    [SerializeField]
    private bool isDebugging = false;
    [SerializeField]
    private GameObject debugingCar;

    private void Awake()
    {
        gameLogic = new GameLogic(this);
        //vulcanController = new VulcanController(fieldController.vulcanParticleSystem);

        if (isDebugging && debugingCar != null)
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

        if (isDebugging && debugingCar != null)
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

    public GameObject GetPlayerCarPrefab()
    {
        return playerCarPrefab;
    }

    public Transform GetPlayerSpawnPos()
    {
        return fieldController.playerSpawnPos;
    }

    //Setters
    public void SetCameraTarget(Transform newTarget)
    {
        camController.SetCameraTarget(newTarget);
    }

}
