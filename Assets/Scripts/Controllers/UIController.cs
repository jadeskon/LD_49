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
    private GameObject character;
    //private GameObject rescuePlace;
    private GameObject vulcanPlace;
    //private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Main_Camera");
        //rescuePlace = GameObject.Find("House");
        vulcanPlace = GameObject.Find("Vulcan");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = vulcanPlace.transform.position;
        Vector3 fromPosition = character.transform.position;

        fromPosition.y = 0;
        toPosition.y = 0;
        //vulcanDirection.y = 0;

        Vector3 dir = (toPosition - fromPosition).normalized;
        

        float angle = Vector3.Angle(fromPosition, toPosition);
        arrowVulcan.transform.localEulerAngles = new Vector3(0, 0, angle);

        /*Debug.Log(dir);
        Debug.Log(angle);*/

        /*
        Vector3 rescuePlaceDirection = rescuePlace.transform.position - character.transform.position;
        rescuePlaceDirection.y = 0;
        rescuePlaceDirection.x = 180;
        arrowRescuePlace.transform.rotation = Quaternion.Euler(rescuePlaceDirection);*/

        textScoreComponent.text = "Score: " + 1;
        textPassengerComponent.text = "Passengers: " + 2;
        textTimeComponent.text = "Time: " + 8;// Time.realtimeSinceStartup;


        if (Input.GetKeyDown(KeyCode.W))
            ActivateGameOverScreen(5, 8);
    }


    public void ActivateGameOverScreen(int score, int passengers)
    {
        textResults.text = "Score: " + score + "\nRescued Passengers: " + passengers;
        gameOverScreen.SetActive(true);   
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
