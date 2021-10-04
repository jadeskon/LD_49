using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Publics
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject ingameScreen;
    public GameObject vulcanPlace;
    public GameObject rescuePointDock;
    public GameObject rescuePointAirfield;
    public GameObject person;
    public Text textScoreComponent;
    public Text textPassengerComponent;
    public Text textTimeComponent;
    public Text textInfo;
    public Text textResults;
    public Image arrowVulcan;
    public Image arrowRescuePoint;
    public Image arrowPerson;

    public GameplayEventSystem gameEventChanel;

    // Privates
    private Camera currentCamera;

    private int score = 0;
    private int passengers = 0;
    private float time = 0;

    private LevelController levelController;

    public void SetLevelController(LevelController levelController)
    {
        this.levelController = levelController;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEventChanel.infoPopupTriggerEvent += Info;

        ingameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        SetTimerDisplay(0);
        SetScoreDisplay(0);
        SetPassengersDisplay(0);

        currentCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (ingameScreen.activeSelf)
        {
            UpdateLandmarkIndicator(vulcanPlace, arrowVulcan);

            float distanceDock = 0;
            float distanceAirfield = 0;

            if (rescuePointDock != null)
                distanceDock = (currentCamera.transform.position - rescuePointDock.transform.position).magnitude;

            if (rescuePointAirfield != null)
                distanceAirfield = (currentCamera.transform.position - rescuePointAirfield.transform.position).magnitude;

            if (distanceDock < distanceAirfield)
                UpdateLandmarkIndicator(rescuePointDock, arrowRescuePoint);
            else
                UpdateLandmarkIndicator(rescuePointAirfield, arrowRescuePoint);

            UpdateLandmarkIndicator(person, arrowPerson);
        }
    }


    public void ActivateGameOverScreen(string reason)
    {
        ingameScreen.SetActive(false);
        pauseScreen.SetActive(false);

        textResults.text = @$"{reason}
But you managed to save {this.passengers} people.

Score: {this.score}";
        gameOverScreen.SetActive(true);
    }

    public void SetTimerDisplay(float time)
    {
        this.time = time;

        int minutes = (int)(time / 60);
        int seconds = ((int)time) % 60;

        textTimeComponent.text = "Time: " + minutes.ToString("d2") + ":" + seconds.ToString("d2");
    }

    public void SetScoreDisplay(int score)
    {
        this.score = score;
        textScoreComponent.text = "Score: " + score;
    }

    public void SetPassengersDisplay(int passengers)
    {
        this.passengers = passengers;
        textPassengerComponent.text = "Passengers: " + passengers;
    }

    public void SetPassenger(GameObject person)
    {
        this.person = person;
    }

    private void UpdateLandmarkIndicator(GameObject targetObject, Image image)
    {
        if (targetObject != null)
        {
            Vector3 dir = currentCamera.transform.forward;

            Vector3 toPosition = targetObject.transform.position;
            Vector3 fromPosition = currentCamera.transform.position;

            Vector3 targetDirection = (fromPosition - toPosition).normalized;

            float degree = Vector3.SignedAngle(dir, targetDirection, Vector3.down);

            targetDirection.z = degree;
    
            targetDirection.x = 0;
            targetDirection.y = 0;

            image.transform.localRotation = Quaternion.Euler(targetDirection);
        }
    }

    public void SwitchPause()
    {
        ingameScreen.SetActive(!ingameScreen.activeSelf);
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    public void Info(string text)
    {
        textInfo.text = text;
    }

    public void ExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartButton()
    {
        Debug.Log("Restart");
        levelController.ResetGame();
        ingameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }
}
