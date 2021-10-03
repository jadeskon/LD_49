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
    private VulcanController vulcanController;

    public GameObject debugingCar;

    private void Awake()
    {
        gameLogic = new GameLogic(soundChanel, inputController, uiController, eventSystem, vulcanController);
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

	public void Reset()
	{
        gameLogic.Reset();
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

    void Update()
    {
        //UpdateInputSystem
    }
}
