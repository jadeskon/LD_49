using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Publics
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject ingameScreen;
    public GameObject vulcanPlace;
    public GameObject rescuePoint;
    public GameObject person;
    public Text textScoreComponent;
    public Text textPassengerComponent;
    public Text textTimeComponent;
    public Text textResults;
    public Image arrowVulcan;
    public Image arrowRescuePoint;
    public Image arrowPerson;


    // Privates
    private GameObject camera;
    
    /*private GameObject vulcanPlace;
    private GameObject rescuePoint;
    private GameObject person;*/

    private int score = 0;
    private int passengers = 0;
    private float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        ingameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        SetTimerDisplay(0);
        SetScoreDisplay(0);
        SetPassengersDisplay(0);

        camera = GameObject.Find("Main Camera");
        
        //vulcanPlace = GameObject.Find("Vulcan");
        //rescuePoint = GameObject.Find("Vulcan");
        //person = GameObject.Find("Person_test");
    }

    // Update is called once per frame
    void Update()
    {
        if (ingameScreen.activeSelf)
        {
            UpdateLandmarkIndicator(vulcanPlace, arrowVulcan);
            UpdateLandmarkIndicator(rescuePoint, arrowRescuePoint);

            //if (person != null)
            UpdateLandmarkIndicator2(person, arrowPerson);
        }
    }


    public void ActivateGameOverScreen()
    {
        ingameScreen.SetActive(false);
        pauseScreen.SetActive(false);

        textResults.text = "Score: " + this.score + "\nRescued Passengers: " + this.passengers;
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
        Vector3 toPosition = targetObject.transform.position;
        Vector3 fromPosition = camera.transform.position;

        Vector3 targetDirection = (fromPosition - toPosition).normalized;

        float radian = Mathf.Atan2(-fromPosition.x, fromPosition.z);

        float degree = radian * 180 / Mathf.PI;

        targetDirection.z = degree + camera.transform.rotation.eulerAngles.y;
        targetDirection.x = 0;
        targetDirection.y = 0;

        image.transform.localRotation = Quaternion.Euler(targetDirection);
    }

    private void UpdateLandmarkIndicator2(GameObject targetObject, Image image)
    {
        Vector3 toPosition = targetObject.transform.position;
        Vector3 fromPosition = camera.transform.position;

        Vector3 targetDirection = (fromPosition - toPosition).normalized;

        float radian = Mathf.Atan2(-fromPosition.x, fromPosition.z);
        float degree = radian * 180 / Mathf.PI;

        targetDirection.z = degree + camera.transform.rotation.eulerAngles.y;
        targetDirection.x = 0;
        targetDirection.y = 0;

        image.transform.localRotation = Quaternion.Euler(targetDirection);
    }

    public void SwitchPause()
    {
        ingameScreen.SetActive(!ingameScreen.activeSelf);
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
