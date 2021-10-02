using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Publics
    public GameObject gameOverScreen;
    public Text textScoreComponent;
    public Text textPassengerComponent;
    public Text textTimeComponent;
    public Text textResults;
    public Image arrowVulcan;
    //public Image arrowRescuePlace;

    // Privates
    private GameObject camera;
    //private GameObject rescuePlace;
    private GameObject vulcanPlace;

    private int score = 0;
    private int passengers = 0;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        SetTimerDisplay(0);
        SetScoreDisplay(0);
        SetPasengersDisplay(0);

        camera = GameObject.Find("Main Camera");
        //rescuePlace = GameObject.Find("House");
        vulcanPlace = GameObject.Find("Vulcan");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLandmarkIndicator(vulcanPlace, arrowVulcan);
    }


    public void ActivateGameOverScreen()
    {
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

    public void SetPasengersDisplay(int passengers)
    {
        this.passengers = passengers;
        textPassengerComponent.text = "Passengers: " + passengers;
    }

    public void UpdateLandmarkIndicator(GameObject targetObject, Image image)
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

    public void ExitButton()
    {
        Application.Quit();
    }

}
